using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_chapter1 : MonoBehaviour
{
    [SerializeField]
    private Player player = null;
    [SerializeField]
    private Transform bossPositionn = null;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject AttackObject1;
    [SerializeField]
    private GameObject AttackObject2;
    [SerializeField]
    private UIManager uIManager;
    private LineRenderer lineRenderer = null;
    private bool isStop = true;
    private bool isPattern1 = false;
    private bool isPattern2 = false;
    private bool isPattern3 = false;
    private bool isPattern4 = false;
    private bool isPattern4_1 = false;
    private bool isPattern5 = false;
    private bool isPattern6 = false;
    private bool isRainShot = false;
    private bool isStoryText_2 = false;
    private bool isStoryText_3 = false;
    private float speed = 0.1f;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        uIManager.OnStoryText(4);
    }
    void Update()
    {
        if (!isStop)
        {
            SeaPlayer();
        }
        if (GameManager.Instance.time <= 48f && !isStoryText_2)
        {
            isStoryText_2 = true;
            uIManager.OnStoryText(9);
        }
        if (GameManager.Instance.time <= 52f && !isPattern1)
        {
            isPattern1 = true;
            Pattern1();
        }
        if (GameManager.Instance.time <= 59f && !isPattern2)
        {
            isPattern2 = true;
            Pattern2();
        }
        if (GameManager.Instance.time <= 47f && !isPattern3)
        {
            isPattern3 = true;
            Pattern3();
        }
        if (GameManager.Instance.time <= 37f && !isPattern4)
        {
            isPattern4 = true;
            Pattern4();
        }
        if (GameManager.Instance.time <= 35f && !isPattern4_1)
        {
            isPattern4_1 = true;
            Pattern4_1();
        }
        if(GameManager.Instance.time <= 27f && !isStoryText_3)
        {
            isStoryText_3 = true;
            uIManager.OnStoryText(17);
        }
        if (GameManager.Instance.time <= 26f && !isPattern5)
        {
            isPattern5 = true;
            Pattern5();
        }
        if (GameManager.Instance.time <= 20f && !isPattern6)
        {
            isPattern6 = true;
            Pattern6();
        }
        if (GameManager.Instance.time <= 10f && !isRainShot)
        {
            isRainShot = true;
            StartCoroutine(RainShot());
        }
        if (Vector2.Distance(player.transform.position, transform.position) <= .5f)
        {
            Player.Instance.StartHit();
        }
    }
    void SeaPlayer()
    {
        Vector2 rot = player.transform.position - bossPositionn.position;
        var angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        //bossPositionn.rotation = Quaternion.Euler(0, 0, angle);
        //Angle = angle + 90;
        lineRenderer.SetPosition(0, bossPositionn.position);
        //if (angle < 0)
        //{
        //    angle += 270;
        //}
        //lineRenderer.SetPosition(1, angle * player.transform.position);
        lineRenderer.SetPosition(1, player.transform.position);
    }

    void Pattern1()
    {
        isPattern1 = true;
        AttackObject1.SetActive(true);
        AttackObject2.SetActive(true);
    }
    void Pattern2()
    {
        isPattern2 = true;
        isStop = false;
        speed = 30f;
        StartCoroutine(RushToTarget());
    }
    void Pattern3()
    {
        isPattern3 = true;
        StartCoroutine(ShotPattern3(15, 3));
    }
    void Pattern4()
    {
        isPattern4 = true;
        speed = 60f;
        StartCoroutine(RushToTarget());
    }
    void Pattern5()
    {
        isPattern5 = true;
        StartCoroutine(ShotPattern5(30, 1));
    }
    void Pattern6()
    {
        isPattern6 = true;
        StartCoroutine(SpinShot(20));
    }
    IEnumerator RushToTarget()
    {
        for (int j = 0; j < 3; j++)
        {
            isStop = false;
            for (int i = 0; i < 3; i++)
            {
                lineRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
                lineRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);
            }
            Vector2 target = player.transform.position;
            isStop = true;
            while (transform.position.x != target.x && transform.position.y != target.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, target,speed *Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            yield return new WaitForSeconds(2f);
        }
        while (transform.position.x != 0 && transform.position.y != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, 1f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator ShotPattern3(int count, int shotNum)
    {
        for (int j = 0; j < shotNum; j++)
        {
            float degree = 0;
            for (int i = 0; i < count; i++)
            {
                var bulletObject = PoolManager.Instance.pool.Pop().GetComponent<Bullet>();
                bulletObject.transform.position = Vector2.zero;
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                float radian = degree * Mathf.Deg2Rad;
                bulletObject.transform.position = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * 0.1f;
                degree += 360 / count;
                degree = degree >= 360 ? degree - 360 : degree;
                bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
                bulletObject.speed = 3f;
            }
            yield return new WaitForSeconds(1f);
            foreach (GameObject bulletObject in GameManager.Instance.Bullets)
            {
                var bullet = bulletObject.GetComponent<Bullet>();
                bullet.speed = 0f;
                Vector2 rot = player.transform.position - bullet.transform.position;
                var angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
            }
            foreach (GameObject bulletObject in GameManager.Instance.Bullets)
            {
                var bullet = bulletObject.GetComponent<Bullet>();
                bullet.speed = 15f;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
    void Pattern4_1()
    {
        AttackObject1.SetActive(true);
        AttackObject2.SetActive(true);
    }
    IEnumerator ShotPattern5(int count, int shotNum)
    {
        for (int j = 0; j < shotNum; j++)
        {
            float degree = 0;
            for (int i = 0; i < count; i++)
            {
                var bulletObject = PoolManager.Instance.pool.Pop().GetComponent<Bullet>();
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                float radian = degree * Mathf.Deg2Rad;
                bulletObject.isPatterned = true;
                bulletObject.transform.position = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * 1f;
                degree += 360 / count;
                degree = degree >= 360 ? degree - 360 : degree;
                bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
                bulletObject.speed = 3f;
            }
            yield return new WaitForSeconds(0.5f);
            foreach (GameObject bulletObject in GameManager.Instance.Bullets)
            {
                var bullet = bulletObject.GetComponent<Bullet>();
                bullet.speed = 0f;
            }
            yield return new WaitForSeconds(0.8f);
            foreach (GameObject bulletObject in GameManager.Instance.Bullets)
            {
                var bullet = bulletObject.GetComponent<Bullet>();
                Vector2 rot = player.transform.position - bullet.transform.position;
                var angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
                bullet.speed = 30f;
                yield return new WaitForSeconds(0.1f);
            }
            foreach (GameObject bulletObject in GameManager.Instance.Bullets)
            {
                var bullet = bulletObject.GetComponent<Bullet>();
                bullet.isPatterned = false;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator SpinShot(int count)
    {
        float degree = 0;
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < count; i++)
            {
                var bulletObject = PoolManager.Instance.pool.Pop().GetComponent<Bullet>();
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                bulletObject.speed = 7f;
                float radian = degree * Mathf.Deg2Rad;
                bulletObject.transform.position = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * 0.2f;
                degree += 360 / count;
                bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
                degree = degree >= 360 ? degree - 360 : degree;
            }
            degree = degree >= 360 ? degree - 360 : degree;
            degree += 10;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public IEnumerator RainShot()
    {
        float randomX = 0;
        while (GameManager.Instance.time >= 1.5f)
        {
            randomX = Random.Range(-8.7f, 8.7f);
            var bulletObject = PoolManager.Instance.pool.Pop().GetComponent<Bullet>();
            GameManager.Instance.AddBulletList(bulletObject.gameObject);
            bulletObject.transform.position = new Vector2(randomX, 4.6f);
            bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            bulletObject.speed = 20f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        uIManager.OnStoryText(27);
    }
}

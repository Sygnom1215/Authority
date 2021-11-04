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
    private bool isPattern1 = false;
    private LineRenderer lineRenderer = null;
    private bool isStop = true;
    private bool isPattern2 = false;
    private bool isPattern3 = false;

    Coroutine pattern2;
    void Start()
    { 
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (!isStop)
        {
            SeaPlayer();
        }
        if (GameManager.Instance.time <= 59f && !isPattern2)
        {
            Pattern2();
        }
        if (GameManager.Instance.time <= 50f && !isPattern1)
        {
            Pattern1();
        }
        if (GameManager.Instance.time <= 45f && !isPattern3)
        {
            Pattern3();
        }
        if (GameManager.Instance.time <= 35f && !isPattern3)
        {
            Pattern2();
        }
        if (Vector2.Distance(player.transform.position, transform.position) <= .5f)
        {
            Player.Instance.StartHit();
        }
    }
    void Pattern1()
    {
        isPattern1 = true;
        AttackObject1.SetActive(true);
        AttackObject2.SetActive(true);
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
    void Pattern2()
    {
        isPattern2 = true;
        isStop = false;
        pattern2 = StartCoroutine(RushToTarget());
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
                transform.position = Vector2.MoveTowards(transform.position, target, 0.1f);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            yield return new WaitForSeconds(2f);
        }
        while (transform.position.x != 0 && transform.position.y != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,Vector2.zero, 0.1f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    void Pattern3()
    {
        isPattern3 = true;
        StartCoroutine(ShotPattern3(10,3));
    }
    IEnumerator ShotPattern3(int count,int shotNum)
    {
        for (int j = 0; j < shotNum; j++)
        {
            float degree = 0;
            for (int i = 0; i < count; i++)
            {
                var bulletObject = Instantiate(bullet).GetComponent<Bullet>();
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                float radian = degree * Mathf.Deg2Rad;
                bulletObject.transform.position = new Vector2(Mathf.Cos(radian)+ transform.position.x, Mathf.Sin(radian) + transform.position.y) * 0.2f;
                degree += 360 / count;
                degree = degree >= 360 ? degree - 360 : degree;
                bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
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
                bullet.speed = 10f;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}

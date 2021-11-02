using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Test : MonoSingletone<Boss_Test>
{
    [SerializeField]
    private SeeTarget tank = null;
    [SerializeField]
    private SeeTarget tank_1 = null;
    [SerializeField]
    private SeeTarget tank_2 = null;
    [SerializeField]
    private GameObject rightUnit;
    [SerializeField]
    private GameObject leftUnit;
    private Vector2 bulletPosition = Vector2.zero;
    private float degree = 0;
    [SerializeField]
    private GameObject bullet;
    int count = 10;
    private bool isSpinPattern1 = false;
    private bool isSpinPattern2 = false;
    private bool isRainShot = false;
    private bool isTankSpawn = false;
    private bool isTankSpawn2 = false;
    private float randomX = 0f;

    Coroutine spinShotCenter;
    Coroutine shotDelay;

    void Start()
    {

    }
    void Update()
    {
        if (!GameManager.Instance.isDead)
        {
            if (GameManager.Instance.time <= 59 && GameManager.Instance.time > 20f && !isSpinPattern1)
            {
                spinShotCenter = StartCoroutine(SpinShotCenter());
            }
            if (GameManager.Instance.time <= 50f && !isTankSpawn)
            {
                TankSpawn();
            }
            if (GameManager.Instance.time <= 30f && !isTankSpawn2)
            {
                TankSpawn2();
            }
            if (GameManager.Instance.time <= 20f && !isSpinPattern2)
            {
                SpinShotRight();
                SpinShotLeft();
            }
            if (GameManager.Instance.time <= 10f && GameManager.Instance.time >= 0f && !isRainShot)
            {
                RainShot();
                shotDelay = StartCoroutine(ShotDelay());
            }
        }
    }
    public void RainShot()
    {
        randomX = Random.Range(-8.7f, 8.7f);
        var bulletObject = Instantiate(bullet).GetComponent<Bullet>();
        GameManager.Instance.AddBulletList(bulletObject.gameObject);
        bulletObject.transform.position = new Vector2(randomX, 7f);
        bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        bulletObject.speed = 20f;
    }
    private IEnumerator ShotDelay()
    {
        isRainShot = true;
        yield return new WaitForSeconds(0.2f);
        isRainShot = false;
    }
    private IEnumerator SpinShotCenter()
    {
        isSpinPattern1 = true;
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < count; i++)
            {
                var bulletObject = Instantiate(bullet).GetComponent<Bullet>();
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                float radian = degree * Mathf.Deg2Rad;
                bulletPosition = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian) + 10f) * 0.2f;
                bulletObject.transform.position = bulletPosition;
                degree += 360 / count;
                bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
                degree = degree >= 360 ? degree - 360 : degree;
            }
            degree = degree >= 360 ? degree - 360 : degree;
            degree += 10;//방향 전환
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(5f);
        isSpinPattern1 = false;
    }
    private void SpinShotRight()
    {
        rightUnit.SetActive(true);
        StartCoroutine(SpinShot2(15f, 8f));
        rightUnit.SetActive(false);
    }
    private void SpinShotLeft()
    {
        leftUnit.SetActive(true);
        isSpinPattern2 = true;
        StartCoroutine(SpinShot2(-15f, 8f));
        leftUnit.SetActive(false);
    }
    private IEnumerator SpinShot2(float x, float y)
    {
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < count; i++)
            {
                var bulletObject = Instantiate(bullet).GetComponent<Bullet>();
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                float radian = degree * Mathf.Deg2Rad;
                bulletPosition = new Vector2(Mathf.Cos(radian) + x, Mathf.Sin(radian) + y) * 0.4f;
                bulletObject.transform.position = bulletPosition;
                degree += 360 / count;
                bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
                degree = degree >= 360 ? degree - 360 : degree;
            }
            degree = degree >= 360 ? degree - 360 : degree;
            degree += 10;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void TankSpawn()
    {
        tank.gameObject.SetActive(true);
        isTankSpawn = true;
    }
    private void TankSpawn2()
    {
        tank_1.gameObject.SetActive(true);
        tank_2.gameObject.SetActive(true);
        isTankSpawn2 = true;
    }
    public void ResetPattern()
    {
        tank_1.gameObject.SetActive(false);
        tank_2.gameObject.SetActive(false);
        tank.gameObject.SetActive(false);
        isSpinPattern1 = false;
        isSpinPattern2 = false;
        isRainShot = false;
        isTankSpawn = false;
        isTankSpawn2 = false;
        StopCoroutine(spinShotCenter);
        if (isRainShot)
        {
            StopCoroutine(shotDelay);
        }
    }
}

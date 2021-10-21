using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBossPattern : MonoSingletone<CircleBossPattern>
{
    [SerializeField]
    private GameObject rightUnit;
    [SerializeField]
    private GameObject leftUnit;
    private Vector2 bulletPosition = Vector2.zero;
    private float degree = 0;
    public GameObject bullet;
    private Bullet bulletObject = null;
    int count = 10;
    private bool isPattern1 = false;
    private bool isPattern2 = false;
    void Start()
    {
        bulletObject = FindObjectOfType<Bullet>();
    }

    void Update()
    {
        if (GameManager.Instance.time <= 59f && GameManager.Instance.time > 20f)
        {
            if(isPattern1 == true)
            {
                return;
            }
            StartCoroutine(SpinShotCenter());
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SpinShotCenter());
            }
        if(GameManager.Instance.time <= 20f && !isPattern2)
        {
            SpinShotRight();
            SpinShotLeft();
        }
    }

    private IEnumerator SpinShotCenter()
    {
        isPattern1 = true;
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < count; i++)
            {
                var bulletObject = Instantiate(bullet).GetComponent<Bullet>();
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                float radian = degree * Mathf.Deg2Rad;
                bulletPosition = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)+10f) * 0.2f;
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
        isPattern1 = false;
    }
    private void SpinShotRight()
    {
        rightUnit.SetActive(true);
        StartCoroutine(SpinShot2(15f,8f));
        rightUnit.SetActive(false);
    }
    private void SpinShotLeft()
    {
        leftUnit.SetActive(true);
        isPattern2 = true;
        StartCoroutine(SpinShot2(-15f,8f));
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
}

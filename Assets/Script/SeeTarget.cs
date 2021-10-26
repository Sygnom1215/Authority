using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeTarget : MonoSingletone<SeeTarget>
{
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private Transform center = null;
    private LineRenderer lineRenderer = null;
    public float Angle = 0;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bullet;
    public bool isPattern1 = false;
    private bool isStop = false;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Debug.Log(GameManager.Instance.time);
        SetRotation();
        SetLinePosition();
        if (GameManager.Instance.time <= 50f && !isPattern1)
        {
            isPattern1 = true;
            StartCoroutine(Pattern1());
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shot(Angle);
        }
    }
    void SetRotation()
    {
        if (!isStop)
        {
            var rot = player.position - center.position;
            var angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
            center.rotation = Quaternion.Euler(0, 0, angle + 90);
            Angle = angle + 90;
        }
    }
    void SetLinePosition()
    {
        if (!isStop)
        {
            lineRenderer.SetPosition(0, player.position);
            lineRenderer.SetPosition(1, center.position);
        }
    }
    public void ShotToTarget()
    {
        Shot(Angle);
    }

    public void Shot(float angle)
    {
        var bulletObject = Instantiate(bullet).GetComponent<Bullet>();
        GameManager.Instance.AddBulletList(bulletObject.gameObject);
        bulletObject.speed = 30f;
        bulletObject.transform.position = bulletPosition.position;
        bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
    public IEnumerator Pattern1()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(1.2f);
        for (int i = 0; i < 3; i++)
        {
            isStop = false;
            yield return new WaitForSeconds(1f);
            isStop = true;
            yield return new WaitForSeconds(0.1f);
            for (int j = 0; j < 3; j++)
            {
                lineRenderer.enabled = false;
                yield return new WaitForSeconds(0.05f);
                lineRenderer.enabled = true;
                yield return new WaitForSeconds(0.05f);
            }
            Shot(Angle);
            yield return new WaitForSeconds(0.2f);
            lineRenderer.enabled = true;

        }
        lineRenderer.enabled = false;
        gameObject.SetActive(false);
    }
}

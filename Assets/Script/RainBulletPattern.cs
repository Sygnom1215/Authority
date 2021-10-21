using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBulletPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private bool isShot = false;
    private float randomX = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.time <= 10f && GameManager.Instance.time >= 0f && !isShot)
        {
            Shot();
            StartCoroutine(ShotDelay());
        }
    }
    public void Shot()
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
        isShot = true;
        yield return new WaitForSeconds(0.2f);
        isShot = false;
    }
}

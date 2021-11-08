using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPatterned = false;
    public float speed = 20f;

    void Start()
    {

    }

    void Update()
    {
        CheckPosition();
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
    }
    public void BulletDestroy()
    {
        //Push();
        GameManager.Instance.RemoveBulletList(gameObject);
        Destroy(gameObject);
    }
    void CheckPosition()
    {
        if (!isPatterned)
        {
            if (transform.position.x >= GameManager.Instance.maxPosition.x || transform.position.y >= GameManager.Instance.maxPosition.y ||
                transform.position.x <= GameManager.Instance.minPosition.x || transform.position.y <= GameManager.Instance.minPosition.y)
            {
                BulletDestroy();
            }
        }
    }

}
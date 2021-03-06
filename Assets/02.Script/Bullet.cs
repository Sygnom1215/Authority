using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Poolable
{
    public bool isPatterned = false;
    public float speed = 0f;

    void Update()
    {
        CheckPosition();
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
    }
    public void BulletDestroy()
    {
        transform.position = Vector2.zero;
        isPatterned = false;
        GameManager.Instance.RemoveBulletList(gameObject);
        Push();
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
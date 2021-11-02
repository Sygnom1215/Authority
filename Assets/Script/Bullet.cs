using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Poolable
{

    public float speed = 20f;

    void Start()
    {
        Invoke("BulletDestroy", 4f);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
    }
    public void BulletDestroy()
    {
        Push();
        //GameManager.Instance.RemoveBulletList(gameObject);
        //Destroy(gameObject);
    }

}
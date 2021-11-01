using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;

    //void Start()
    //{
    //    Invoke("BulletDestroy", 4f);
    //}

    void Update()
    {
         transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
    }
    public void BulletDestroy()
    {
        
        //Destroy(gameObject);
    }

    public void OnBecameInvisible()
    {
        if( GameManager.Instance != null )
            GameManager.Instance.RemoveBulletList(gameObject);
    }

}

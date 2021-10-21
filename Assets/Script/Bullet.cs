using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BulletDestroy", 4f);
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
    }
    void BulletDestroy()
    {
        GameManager.Instance.RemoveBulletList(gameObject);
        Destroy(gameObject);

    }
  
}

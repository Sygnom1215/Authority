using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePattern : MonoBehaviour
{
    private float degree = 0;
    private Vector2 bulletPosition = Vector2.zero;
    int count = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)){

        }
    }
    private void shot(GameObject bullet, float radius, float x, float y)
    {

            for (int i = 0; i < count; i++)
            {
                var bulletObject = Instantiate(bullet).GetComponent<Bullet>();
                GameManager.Instance.AddBulletList(bulletObject.gameObject);
                float radian = degree * Mathf.Deg2Rad;
                bulletPosition = new Vector2(Mathf.Cos(radian) + x, Mathf.Sin(radian) + y) * radius;
                bulletObject.transform.position = bulletPosition;
                degree += 360 / count;
                bulletObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
                degree = degree >= 360 ? degree - 360 : degree;
            }
    }
}

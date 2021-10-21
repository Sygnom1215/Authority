using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    Vector2 originPos = Vector2.zero;
    private void Start()
    {
        originPos = transform.position;
    }
    public IEnumerator Shake(float time)
    {
        for (int i = 0; i < time * 100; i++)
        {
            transform.position = (Vector2)transform.position + (Random.insideUnitCircle * .8f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            yield return new WaitForSeconds(.01f);
            transform.position = originPos;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            yield return new WaitForSeconds(.01f);
        }
    }
}

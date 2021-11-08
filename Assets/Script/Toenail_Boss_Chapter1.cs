using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toenail_Boss_Chapter1 : MonoBehaviour
{
    LineRenderer line;
    private bool isDanger = false;
    private bool isOnSprite = false;
    private SpriteRenderer sprite;
    float x;
    float y;
    [SerializeField]
    float addX;
    [SerializeField]
    float addY;
    [SerializeField]
    float hitX;
    [SerializeField]
    float hitY;
    Coroutine dangerLine;
    void Start()
    { 
        sprite = GetComponent<SpriteRenderer>();
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Invoke("OffObject", 4f);
        if (isOnSprite)
        {
            if (Mathf.Abs(transform.position.y - Player.Instance.transform.position.y) <= hitY && Mathf.Abs(transform.position.x - Player.Instance.transform.position.x) <= hitX)
            {
                if (this.gameObject.activeInHierarchy)
                {
                    Player.Instance.StartHit();
                }
                Debug.Log("Hit");
            }
        }
        else if (!isDanger)
        {
            dangerLine = StartCoroutine(Danger());
        }
    }
    IEnumerator Danger()
    {
        isDanger = true;
        x = Player.Instance.transform.position.x;
        y = Player.Instance.transform.position.y;
        line.SetPosition(0, new Vector2(x - addX, y - addY));
        line.SetPosition(1, new Vector2(x + addX, y + addY));
        for (int i =0; i <2; i++)
        {
            line.enabled = true;
            yield return new WaitForSeconds(0.15f);
            line.enabled = false;
            yield return new WaitForSeconds(0.15f);
        }
        OnSprite();
    }
    void OnSprite()
    {
        sprite.enabled = true;
        transform.position = new Vector2(x,y);
        isOnSprite = true;
    }
    void OffObject()
    {
        sprite.enabled = false;
        transform.position = Vector2.zero;
        isOnSprite = false;
        isDanger = false;
        gameObject.SetActive(false);
    }
}

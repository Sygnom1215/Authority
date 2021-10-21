using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
 
    private bool isDamage = false;

    private Vector2 moveDir;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] sprites = null;

    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Hit();
        Move();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 Position = transform.position;
        Position.x = Mathf.Clamp(Position.x, GameManager.Instance.minPosition.x, GameManager.Instance.maxPosition.x);
        Position.y = Mathf.Clamp(Position.y, GameManager.Instance.minPosition.y, GameManager.Instance.maxPosition.y);

        moveDir = new Vector2(x, y).normalized;
        if(x == -1)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if(x == 1)
        {
            spriteRenderer.sprite = sprites[0];
        }
        Position.x += moveDir.x * Time.deltaTime * speed;
        Position.y += moveDir.y * Time.deltaTime * speed;

        transform.position = Position;
    }
    public void Hit()
    {
        foreach (GameObject bullet in GameManager.Instance.Bullets)
        {
            if (Vector2.Distance(transform.position, bullet.transform.position) <= .2f)
            {
                    Debug.Log("HIT2");
                    StartCoroutine(HitAnimation());
            }
        }
    }
    public IEnumerator HitAnimation()
    {
        if (!isDamage)
        {
            isDamage = true;
            GameManager.Instance.life--;
            StartCoroutine(Camera.main.GetComponent<ShakeCamera>().Shake(.05f));
            for (int i = 0; i < 3; i++)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
            isDamage = false;
        }
    }
}

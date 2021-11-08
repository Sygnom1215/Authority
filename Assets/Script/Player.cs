using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoSingletone<Player>
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private GameObject GameOverPrefab;
    [SerializeField]
    private Text TimeRemaining;

    private bool isDamage = false;

    private Vector2 moveDir;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] sprites = null;

    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!GameManager.Instance.isDead)
        {
            HitCheck();
            Move();
        }
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
    public void HitCheck()
    {
        foreach (GameObject bullet in GameManager.Instance.Bullets)
        {
            if (Vector2.Distance(transform.position, bullet.transform.position) <= .2f)
            {
                StartCoroutine(Hit());
            }
        }
    }
    private void GameOver()
    {
        GameManager.Instance.life = 0;
        GameManager.Instance.isDead = true;
        GameOverPrefab.SetActive(true);
        TimeRemaining.text = "남은시간 : " + $"{GameManager.Instance.time:N2}";
        Time.timeScale = 0;
    }
    public IEnumerator Hit()
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
            if(GameManager.Instance.life <= 0)
            {
                GameOver();
            }
        }
    }
    public void StartHit()
    {
        if (!isDamage)
        {
            StartCoroutine(Hit());
        }
    }
}

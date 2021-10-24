using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingletone<GameManager>
{
    public int life  = 5;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private SeeTarget tank = null;
    [SerializeField]
    private SeeTarget tank_1 = null;
    [SerializeField]
    private SeeTarget tank_2 = null;
    [SerializeField]
    private GameObject Win;
    public List<GameObject> Bullets;
    public Vector2 maxPosition = new Vector2(8.7f,4.7f);
    public Vector2 minPosition = new Vector2(-8.7f, -4.7f);
    public float time { get; private set; } = 60f;
    private bool timeOver = false;
    private bool isTankSpawn = false;
    private bool isTankSpawn2 = false;
    public bool isDead = false;
    private void Start()
    {
        Bullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bullet"));
    }
    void Update()
    {
        if (!timeOver)
        {
            if (!isDead)
            {
                TimeCheck();
                if (time <= 50f && !isTankSpawn)
                {
                    TankSpawn();
                }
                if (time <= 30f && !isTankSpawn2)
                {
                    TankSpawn2();
                }
            }
        }
        else
        {
            Win.SetActive(true);
        }
    }
    private void TimeCheck()
    {
        if(time <= 0)
        {
            timeOver = true;
            return;
        }
        time -= Time.deltaTime;
        timeText.text = $"{time:N2}";
    }
    public void AddBulletList(GameObject bullet)
    {
        Bullets.Add(bullet);
    }
    public void RemoveBulletList(GameObject bullet)
    {
        Bullets.Remove(bullet);
    }
    private void TankSpawn()
    {
        tank.gameObject.SetActive(true);
        isTankSpawn = true;
    }
    private void TankSpawn2()
    {
        tank_1.gameObject.SetActive(true);
        tank_2.gameObject.SetActive(true);
        isTankSpawn2 = true;
    }
}

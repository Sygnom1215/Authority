using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingletone<GameManager>
{
    public int life = 5;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text lifeText;
    [SerializeField]
    private SeeTarget tank = null;
    [SerializeField]
    private SeeTarget tank_1 = null;
    [SerializeField]
    private SeeTarget tank_2 = null;
    [SerializeField]
    private GameObject Win;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject GameOverPrefab;
    public List<GameObject> Bullets;
    public Vector2 maxPosition = new Vector2(8.7f, 4.7f);
    public Vector2 minPosition = new Vector2(-8.7f, -4.7f);
    public float time { get; private set; } = 60f;
    private bool timeOver = false;
    private bool isTankSpawn = false;
    private bool isTankSpawn2 = false;
    private bool isOpenMenu = false;
    public bool isDead = false;
    private void Start()
    {
        Bullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bullet"));
        lifeText.text = string.Format("Life {0}", GameManager.Instance.life);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpenMenu)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
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
        if (time <= 0)
        {
            timeOver = true;
            return;
        }
        time -= Time.deltaTime;
        timeText.text = $"{time:N2}";
        lifeText.text = string.Format("Life {0}", GameManager.Instance.life);
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
    private void OpenMenu()
    {
        isOpenMenu = true;
        menu.SetActive(true);
        Time.timeScale = 0;

    }
    public void CloseMenu()
    {
        isOpenMenu = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        time = 60f;
        life = 5;
        GameOverPrefab.SetActive(false);
        isDead = false;
    }
    public void BossPatternReset()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingletone<GameManager>
{
    public int life = 5;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text lifeText;
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
    public bool timeOver { get; private set; } = false;
    private bool isOpenMenu = false;
    public bool isDead = false;
    private void Start()
    {
        Bullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bullet"));
        lifeText.text = string.Format("Life {0}", life);
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
        if (!timeOver || !isDead)
        {
           TimeCheck();
        }
    }
    public void TimeCheck()
    {
            if (time <= 0)
            {
            Win.SetActive(true);
            timeOver = true;
                return;
            }
            time -= Time.deltaTime;
            timeText.text = $"{time:N2}";
            lifeText.text = string.Format("Life {0}", life);
    }
    public void AddBulletList(GameObject bullet)
    {
        Bullets.Add(bullet);
    }
    public void RemoveBulletList(GameObject bullet)
    {
        Bullets.Remove(bullet);
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
    public void Boss_Test_PatternReset()
    {
        ResetBullet();
        Player.Instance.transform.position = new Vector2(0, -3);
        time = 60f;
        Time.timeScale = 1;
        life = 5;
        GameOverPrefab.SetActive(false);
        Boss_Test.Instance.ResetPattern();
        isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ResetBullet()
    {
        foreach(GameObject bullet in Bullets)
        {
            Destroy(bullet);
        }
        Bullets = new List<GameObject>();
    }
}

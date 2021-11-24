using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    private Text stageText;
    [SerializeField]
    private Text loreText;
    [SerializeField]
    private List<string> stageTexts = new List<string>();
    [SerializeField]
    private List<string> loreTexts = new List<string>();
    [SerializeField]
    private GameObject[] stageLoreTexts;
    [SerializeField]
    private Sprite[] sprites = null;
    [SerializeField]
    private GameObject lorePanel;
    [SerializeField]
    private GameObject leftButton;
    [SerializeField]
    private GameObject rightButton;
    [SerializeField]
    private GameObject menu;

    private int cnt = 0;
    private SpriteRenderer spriteRenderer;

    private bool isMaxLeft = false;
    private bool isMaxRight = false;
    private bool isOpenLore = false;
    private bool isOpenMenu = false;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckCnt();

        stageText.text = stageTexts[cnt];
        loreText.text = loreTexts[cnt];

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpenLore)
            {
                OnClickCloseLore();
            }
            else if (isOpenMenu)
            {
                menu.SetActive(false);
                isOpenMenu = false;
            }
            else
            {
                menu.SetActive(true);
                isOpenMenu = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isOpenLore)
                OnClickCloseLore();
            OnClickLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isOpenLore)
                OnClickCloseLore();
            OnClickRight();
        }
    }
    public void CheckCnt()
    {
        if (cnt == 0)
        {
            isMaxLeft = true;
            leftButton.SetActive(false);
        }
        else
        {
            isMaxLeft = false;
            leftButton.SetActive(true);
        }

        if (cnt == 4)
        {
            isMaxRight = true;
            rightButton.SetActive(false);
        }
        else
        {
            isMaxRight = false;
            rightButton.SetActive(true);
        }
    }
    public void OnClickRight()
    {
        if (isMaxRight) return;
        AudioManager.Instance.PlayButtonSound();
        cnt++;
        spriteRenderer.sprite = sprites[1];
        transform.Translate(Vector2.right * 50, Space.Self);
    }
    public void OnClickLeft()
    {
        if (isMaxLeft) return;
        AudioManager.Instance.PlayButtonSound();
        cnt--;
        spriteRenderer.sprite = sprites[0];
        transform.Translate(Vector2.left * 50, Space.Self);
    }
    public void OnClickSelect()
    {
        isOpenLore = true;
        lorePanel.SetActive(true);
        stageLoreTexts[cnt].SetActive(true);
    }
    public void OnClickCloseLore()
    {
        isOpenLore = false;
        lorePanel.SetActive(false);
        stageLoreTexts[cnt].SetActive(false);
    }
    public void OnClickTaecho()
    {
        //Debug.Log("저기봐 피카츄 태초마을이야! / 피카피카!");
        SceneManager.LoadScene("GameStart");
        Time.timeScale = 1;
    }
    public void OnClickStart()
    {
        switch (cnt)
        {
            case 0:
                SceneManager.LoadScene("PlayScene");
                Time.timeScale = 1;
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }
}

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
    [SerializeField]
    private GameObject errorPanel;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpenLore)
            {
                OnClickStart();
            }
            else
            {
                OnClickSelect();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpenLore)
            {
                OnClickCloseLore();
            }
            //else if (isOpenMenu)
            //{
            //    OnClickCloseMenu();
            //}
            //else
            //{
            //    OnClickOpenMenu();
            //}
            else
            {
                OnClickTaecho();
            }
        }
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (cnt != 0) // ???????????? ?????? ?? if ????????
            {
                if (isOpenLore)
                    OnClickCloseLore();
                OnClickLeft();
            }
            OnClickLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(cnt != 0)
            {
                if (isOpenLore)
                    OnClickCloseLore();
                OnClickRight();
            }
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
        if (cnt != 0)
        {
            if (isMaxRight) return;
            if (isOpenLore)
                OnClickCloseLore();
            AudioManager.Instance.PlayButtonSound();
            cnt++;
            spriteRenderer.sprite = sprites[1];
            transform.Translate(Vector2.right * 50, Space.Self);
        }
        if (isMaxRight) return;
        errorPanel.SetActive(true);
        Invoke("OnClickCloseError", 1.5f);
    }
    public void OnClickLeft()
    {
        if (cnt != 0)
        {
            if (isOpenLore)
                OnClickCloseLore();
            if (isMaxLeft) return;
            AudioManager.Instance.PlayButtonSound();
            cnt--;
            spriteRenderer.sprite = sprites[0];
            transform.Translate(Vector2.left * 50, Space.Self);
        }
        if (isMaxLeft) return;
        errorPanel.SetActive(true);
        Invoke("OnClickCloseError", 1.5f);
    }
    public void OnClickSelect()
    {
        isOpenLore = true;
        lorePanel.SetActive(true);
        stageLoreTexts[cnt].SetActive(true);
        AudioManager.Instance.PlayButtonSound();
    }
    public void OnClickCloseLore()
    {
        isOpenLore = false;
        lorePanel.SetActive(false);
        stageLoreTexts[cnt].SetActive(false);
        AudioManager.Instance.PlayButtonSound();
    }
    public void OnClickTaecho()
    {
        SceneManager.LoadScene("01. GameStart");
        Time.timeScale = 1;
    }
    public void OnClickOpenMenu()
    {
        menu.SetActive(true);
        isOpenMenu = true;
    }
    public void OnClickCloseMenu()
    {
        menu.SetActive(false);
        isOpenMenu = false;
    }
    public void OnClickStart()
    {
        switch (cnt)
        {
            case 0:
                SceneManager.LoadScene("03.PlayScene");
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
    public void OnClickCloseError()
    {
        errorPanel.SetActive(false);
    }
}

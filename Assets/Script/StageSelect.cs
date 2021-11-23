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
    private Text stageLoreText;
    [SerializeField]
    private List<string> stageTexts = new List<string>();
    [SerializeField]
    private List<string> stageLoreTexts = new List<string>();
    [SerializeField]
    private GameObject lorePanel;
    [SerializeField]
    private GameObject leftButton;
    [SerializeField]
    private GameObject rightButton;
    private int cnt = 0;

    private bool isMaxLeft = false;
    private bool isMaxRight = false;
    private bool isOpenLore = false;

    void Update()
    {
        CheckCnt();

        stageText.text = stageTexts[cnt];
        stageLoreText.text = stageLoreTexts[cnt];

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOpenLore) return;
            OnClickCloseLore();
        }
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
            OnClickLeft();
        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
            OnClickRight();
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
        cnt++;
        transform.Translate(Vector2.right * 50, Space.Self);
    }
    public void OnClickLeft()
    {
        if (isMaxLeft) return;
        cnt--;
        transform.Translate(Vector2.left * 50, Space.Self);
    }
    public void OnClickSelect()
    {
        isOpenLore = true;
        lorePanel.SetActive(true);
    }
    public void OnClickCloseLore()
    {
        isOpenLore = false;
        lorePanel.SetActive(false);
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

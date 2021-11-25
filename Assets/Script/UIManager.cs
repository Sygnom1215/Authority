using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;
    [SerializeField]
    private RectTransform textObjectPos;
    [SerializeField]
    private Text text;
    [SerializeField]
    private List<string> texts = new List<string>();
    [SerializeField]
    private List<Vector2> textPos = new List<Vector2>();
    [SerializeField]
    private GameObject button = null;
    private int endTextCnt = 0;
    private int textCnt = 0;
    public bool isStroyed { get; private set; } = false;
    /* 해야 하는 거 
     * pause << 당장에 만들 수 있는거 ??
     * Scene Out 
     */

    public void OnClickCloseMenu()
    {
        if (!isStroyed)
        {
            GameManager.Instance.CloseMenu();
        }
    }
    public void OnClickRestart()
    {
        if (!isStroyed)
        {
            GameManager.Instance.Boss_Test_PatternReset();
        }
    }
    public void OnClickGoToMenu()
    {
        if (!isStroyed)
        {
            SceneManager.LoadScene("Stage");
            Time.timeScale = 1;
        }
    }
    public void OnStoryText(int endTextNumber)
    {
        Time.timeScale = 0;
        button.SetActive(true);
        isStroyed = true;
        endTextCnt = endTextNumber;
        text.text = string.Format(texts[textCnt]);
        textObjectPos.anchoredPosition = textPos[textCnt];
        textObject.SetActive(true);
        textCnt++;
    }
    public void NextText()
    {
        if (isStroyed)
        {
                if (textCnt >= endTextCnt)
                {
                    Debug.Log(textCnt & endTextCnt);
                    Time.timeScale = 1;
                    textObject.SetActive(false);
                    button.SetActive(false);
                    isStroyed = false;
                }
                else
                {
                    OnStoryText(endTextCnt);
                }
        }
    }
}

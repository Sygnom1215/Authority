using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject storyTextPanel;
    [SerializeField]
    private GameObject textObject;
    [SerializeField]
    private RectTransform textObjectPos;
    [SerializeField]
    private Image characterImage;
    [SerializeField]
    private Text text;
    [SerializeField]
    private List<string> texts = new List<string>();
    [SerializeField]
    private List<Vector2> textPos = new List<Vector2>();
    [SerializeField]
    private List<Sprite> characterSprite = new List<Sprite>();
    private int endTextCnt = 0;
    private int textCnt = 0;
    public bool isStroyed { get; private set; } = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameManager.Instance.isOpenMenu)
            {
                if (isStroyed)
                {
                    if (textCnt >= endTextCnt)
                    {
                        Debug.Log(textCnt & endTextCnt);
                        Time.timeScale = 1;
                        //textObject.SetActive(false);
                        storyTextPanel.SetActive(false);
                        isStroyed = false;
                    }
                    else
                    {
                        OnStoryText(endTextCnt);
                    }
                }
            }
        }
    }
    public void OnClickCloseMenu()
    {

            GameManager.Instance.CloseMenu();

    }
    public void OnClickRestart()
    {

            GameManager.Instance.Boss_Test_PatternReset();
  
    }
    public void OnClickGoToMenu()
    {

            SceneManager.LoadScene("02. Stage");
            Time.timeScale = 1;
        
    }
    public void OnStoryText(int endTextNumber)
    {
        Time.timeScale = 0;
        isStroyed = true;
        endTextCnt = endTextNumber;
        text.text = string.Format(texts[textCnt]);
        characterImage.sprite = characterSprite[textCnt];
        storyTextPanel.SetActive(true);
        textCnt++;
    }
}

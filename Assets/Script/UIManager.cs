using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;
    [SerializeField]
    private Text text;
    [SerializeField]
    private List<string> texts = new List<string>();
    [SerializeField]
    private List<Vector2> textPos = new List<Vector2>();

    private int textCnt = 0;
    /* 해야 하는 거 
     * pause << 당장에 만들 수 있는거 ??
     * Scene Out 
     */

    void Start()
    {
        text.text = string.Format(texts[textCnt]);
        textObject.GetComponent<RectTransform>().anchoredPosition = textPos[textCnt];
    }

    void Update()
    {
        
    }

    public void OnClickCloseMenu()
    {
        GameManager.Instance.CloseMenu();
    }
    public void OnClickRestart()
    {
        GameManager.Instance.Boss_Test_PatternReset();
    }
}

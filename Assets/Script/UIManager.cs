using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Text> texts = new List<Text>();
    [SerializeField]
    private List<float> textX = new List<float>();
    [SerializeField]
    private List<float> textY = new List<float>();
    /* 해야 하는 거 
     * pause << 당장에 만들 수 있는거 ??
     * Scene Out 
     */

    void Start()
    {
        
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

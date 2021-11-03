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
    /* �ؾ� �ϴ� �� 
     * pause << ���忡 ���� �� �ִ°� ??
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

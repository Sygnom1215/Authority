using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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

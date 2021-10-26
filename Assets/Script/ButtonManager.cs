using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnClickCloseMenu()
    {
        GameManager.Instance.CloseMenu();
    }
    public void OnClickRestart()
    {
        GameManager.Instance.Restart();
    }
}

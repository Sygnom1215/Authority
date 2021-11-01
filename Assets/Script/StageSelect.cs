using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    private int cnt = 0;
    private bool isMaxLeft = false;
    private bool isMaxRight = false;
    void Start()
    {

    }

    void Update()
    {
        if (cnt == 0) isMaxLeft = true;
        else isMaxLeft = false;
        if (cnt == 4) isMaxRight = true;
        else isMaxRight = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
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
        switch (cnt)
        {
            case 0:
                SceneManager.LoadScene("PlayScene");
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

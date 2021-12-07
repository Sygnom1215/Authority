using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    [SerializeField]
    private GameObject exitPanel;
    [SerializeField]
    private GameObject gameLore;
    [SerializeField]
    private GameObject[] lores;

    private int loreCnt = 0;

    private bool isOpenLore = false;
    private bool isOpenExit = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpenLore)
            {
                CloseLore();
            }
            else
            {
                if(isOpenExit)
                {
                    OnClickCloseExit();
                }
                else
                {
                    OnClickExit();
                }
            }
        }
        if (isOpenLore)
        {
            if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
                BackLore();
            if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
                NextLore();
        }
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("02. Stage");
        Time.timeScale = 1;
    }
    public void OnClickLore()
    {
        gameLore.SetActive(true);
        lores[0].SetActive(true);
        isOpenLore = true;
    }
    public void CloseLore()
    {
        gameLore.SetActive(false);
        lores[loreCnt].SetActive(false);
        loreCnt = 0;
        isOpenLore = false;
    }
    public void NextLore()
    {
        if (loreCnt == 3) return;
        lores[loreCnt].SetActive(false);
        loreCnt++;
        lores[loreCnt].SetActive(true);
    }
    public void BackLore()
    {
        if (loreCnt == 0) return;
        lores[loreCnt].SetActive(false);
        loreCnt--;
        lores[loreCnt].SetActive(true);
    }
    public void OnClickExit()
    {
        if (isOpenExit) return;
        exitPanel.SetActive(true);
        isOpenExit = true;
    }
    public void OnClickCloseExit()
    {
        isOpenExit = false;
        exitPanel.SetActive(false);
    }
    public void OnClickGameQuit()
    {
        Application.Quit();
    }
}

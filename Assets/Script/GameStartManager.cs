using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameLore;

    private bool isOpenLore;

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

            }
        }
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("Stage");
        Time.timeScale = 1;
    }
    public void OnClickLore()
    {
        gameLore.SetActive(true);
        isOpenLore = true;
    }
    public void CloseLore()
    {
        gameLore.SetActive(false);
        isOpenLore = false;
    }
    public void OnClickExit()
    {

    }
}

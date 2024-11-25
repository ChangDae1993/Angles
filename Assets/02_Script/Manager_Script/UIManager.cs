using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using TMPro;

public class UIManager : MonoBehaviour
{
    public enum stagecount
    {
        MainScene = 0,
        IntroScene = 1,
        PlayScene = 2,
    }

    public stagecount stgCNt;

    [Header("Main Scene")]
    public GameObject BtnGroup;

    [Space(10f)]

    [Header("Stage Scene")]
    public bool windowOnOff = false;

    public Image optionPanel;
    public bool gamePause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(!GameManager.GM.GPM.GameEnd)
        {
            if (GameManager.GM.UM.stgCNt > (UIManager.stagecount)1)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!windowOnOff)
                    {
                        gamePause = true;
                        OptionShow(true);
                        Time.timeScale = 0f;
                        windowOnOff = true;
                    }
                    else
                    {
                        gamePause = false;
                        OptionShow(false);
                        Time.timeScale = 1f;
                        windowOnOff = false;
                    }
                }
            }
        }
    }


    public void OptionShow(bool onoff)
    {
        if (onoff)
        {
            optionPanel.gameObject.SetActive(true);
        }
        else
        {
            optionPanel.gameObject.SetActive(false);
        }
    }

    public void OptionResumeBtn()
    {
        gamePause = false;
        OptionShow(false);
        Time.timeScale = 1f;
        windowOnOff = false;
    }

    public void OptionGiveUpBtn()
    {
        List<string> keys = new List<string>(GlobalItemData.itemData.Keys);
        Time.timeScale = 1f;
       
        for (int i = 0; i < keys.Count; i++)
        {
            string key = keys[i];
            GlobalItemData.itemData[key] = 1;
        }

        //GameManager.GM.GPM.gameTime = 0f;

        stgCNt = stagecount.MainScene;

        windowOnOff = false;
        OptionShow(false);
        SceneManager.LoadScene(0);
        if (!BtnGroup.activeSelf)
        {
            BtnGroup.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

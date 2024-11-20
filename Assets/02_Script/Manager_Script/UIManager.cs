using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    public SceneChangeManager scm;
    //public void BackToMenuBtn()
    //{
    //    OptionShow(false);
    //    GlobalItemData.itemData.Clear();
    //    scm.ChangeScene(0);
    //}

    public void ExitGame()
    {
        Application.Quit();
    }

}

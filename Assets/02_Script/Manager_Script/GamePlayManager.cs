using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
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
        if(GameManager.GM.UM.stgCNt > (UIManager.stagecount)1)
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
        if(onoff )
        {
            optionPanel.gameObject.SetActive(true);
        }
        else
        {
            optionPanel.gameObject.SetActive(false);
        }
    }
}

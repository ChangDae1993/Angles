using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    //public float gameTime;
    //public float maxGameTime;

    public EnemyPoolManager EnemyPoolManager;

    public Image ClearPanel;

    public bool GameEnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEnd = false;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (GameManager.GM.UM.stgCNt > (UIManager.stagecount)1)
    //    //{
    //    //    gameTime += Time.deltaTime;

    //    //    if (gameTime > maxGameTime)
    //    //    {
    //    //        gameTime = maxGameTime;
    //    //    }
    //    //}
    //}


    public void EndGameOn()
    {
        GameEnd = true;
        Time.timeScale = 0f;

        ClearPanel.gameObject.SetActive(true);
        //Debug.Log("선별 되었습니다. 테스트를 종료합니다. 하고 메인 화면으로 다시 나가기 버튼 띄우기");

    }


    public void ClearBackMenuBtn()
    {
        GameManager.GM.UM.stgCNt = UIManager.stagecount.MainScene;

        if (GameManager.GM.player != null)
        {
            GameManager.GM.player = null;
        }

        if (GameManager.GM.player_state != null)
        {
            GameManager.GM.player_state = null;
        }
        
        if(ClearPanel.gameObject.activeSelf)
        {
            ClearPanel.gameObject.SetActive(false);
        }

        if (!GameManager.GM.UM.BtnGroup.activeSelf)
        {
            GameManager.GM.UM.BtnGroup.SetActive(true);
        }

        GameEnd = false; 
        GameManager.GM.SCM.ChangeScene(0);
    }

}

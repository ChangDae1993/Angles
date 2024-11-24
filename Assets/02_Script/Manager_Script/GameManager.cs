using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;   //Singleton instance
    [Header("Manager")]
    public UIManager UM;

    public SceneChangeManager SCM;
    public GamePlayManager GPM;

    [Space(10f)]
    public GameObject player = null;
    public Player_State player_state = null;

    public void Awake()
    {
        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }


        //Debug.Log("Awake");
        if (GM == null)
        {
            // 현재 인스턴스가 Singleton 인스턴스가 됨
            GM = this;
            //Debug.Log("start");
            DontDestroyOnLoad(this.gameObject); // 이 객체는 Scene이 바뀌어도 파괴되지 않음
        }
        else if (GM != this)
        {
            // Singleton 인스턴스가 이미 존재하면 자신을 파괴
            Debug.Log("start2");
            Destroy(this.gameObject);
            return;
        }


        if(!GPM.ClearPanel.gameObject.activeSelf)
        {
            GPM.ClearPanel.gameObject.SetActive(false);
        }

        // Manager 객체를 초기화
        InitializeManagers();

//#if UNITY_EDITOR
//        Cursor.visible = true;
//#else
//        Cursor.visible = false;
//#endif

    }

    private void InitializeManagers()
    {
        if (UM == null)
        {
            UM = this.transform.Find("UIManager").GetComponent<UIManager>();
        }

        if (SCM == null)
        {
            SCM = this.transform.Find("SceneManager").GetComponent<SceneChangeManager>();
        }

        if (GPM == null)
        {
            GPM = this.transform.Find("GamePlayManager").GetComponent<GamePlayManager>();
        }
    }
}

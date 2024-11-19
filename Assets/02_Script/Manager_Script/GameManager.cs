using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    [Header("UI Manager")]
    public UIManager UM;
    [Space(10f)]
    public Player player;

    public SceneChangeManager SCM;


    private void Awake()
    {
        GM = this;

        //Debug.Log("Awake");
        if (GM == null)
        {
            Debug.Log("start");
            DontDestroyOnLoad(this.gameObject);

            GM = this;
        }
        else if (GM != this)
        {
            Debug.Log("start2");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("start3");
            DontDestroyOnLoad(gameObject);
        }

        UM = this.transform.Find("UIManager").GetComponent<UIManager>();
        SCM = this.transform.Find("SceneManager").GetComponent<SceneChangeManager>();


//#if UNITY_EDITOR
//        Cursor.visible = true;
//#else
//        Cursor.visible = false;
//#endif

    }

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
}

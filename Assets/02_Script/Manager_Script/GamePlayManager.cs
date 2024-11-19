using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public bool windowOnOff = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!windowOnOff)
            {
                Time.timeScale = 0f;
                windowOnOff = true;
            }
            else
            {
                Time.timeScale = 1f;
                windowOnOff = false;
            }
        }

    }
}

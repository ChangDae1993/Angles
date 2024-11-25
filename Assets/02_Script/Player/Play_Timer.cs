using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Play_Timer : MonoBehaviour
{
    public Text timerTxt;

    public float surviveTime;
    public float timeRemaining;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        surviveTime = surviveTime * 60f;
        timeRemaining = surviveTime;
    }

    // Update is called once per frame
    public void Update()
    {
        if (GameManager.GM.UM.stgCNt >= (UIManager.stagecount)2)
        {

            if (timeRemaining > 0)
            {

#region cheat Code

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.K))
                {
                    timeRemaining = timeRemaining - 10f;
                    Debug.Log("Cheat On");
                }
#endregion


                timeRemaining -= Time.deltaTime; // 남은 시간 감소
                UpdateTimerUI();
            }
            else
            {
                //Debug.Log("타이머가 종료되었습니다!");
                timeRemaining = 0; // 남은 시간을 0으로 고정
                GameManager.GM.GPM.EndGameOn();
                //isTimerRunning = false; // 타이머 중지'
                //endTrue = false;
            }
        }

    }

    void UpdateTimerUI()
    {
        // 시간을 분:초 형식으로 변환하여 표시
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

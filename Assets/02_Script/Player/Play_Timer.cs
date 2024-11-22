using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Play_Timer : MonoBehaviour
{
    public TextMeshProUGUI Min_timerTxt;
    public TextMeshProUGUI Sec_timerTxt;

    private float timeRemaining = 60f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void UpdateTimerUI()
    //{
    //    // 시간을 분:초 형식으로 변환하여 표시
    //    int minutes = Mathf.FloorToInt(timeRemaining / 60);
    //    int seconds = Mathf.FloorToInt(timeRemaining % 60);
    //    timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    //}
}

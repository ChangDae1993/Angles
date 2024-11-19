using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public Image btnColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region 버튼 공통 연출
    public void ButtonPointerIn()
    {
        btnColor.color = Color.red;
        //Debug.Log("button on");
    }

    public void ButtonPointerOut()
    {
        btnColor.color = Color.white;
        //Debug.Log("button off");
    }
    #endregion
}

using UnityEngine;

public class UIManager : MonoBehaviour
{

    public int indexSelector = 0;

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
        Debug.Log("button on");
    }

    public void ButtonPointerOut()
    {
        Debug.Log("button off");
    }
    #endregion
}

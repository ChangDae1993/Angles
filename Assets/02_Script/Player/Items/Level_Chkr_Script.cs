using UnityEngine;

public class Level_Chkr_Script : MonoBehaviour
{
    public GameObject thisWeapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void levelChck(int level)
    {
        //개별 무기 동작 스크립트에서 Upgrade 함수는 무조건 있어야함.
        thisWeapon.SendMessage("Upgrade", level);

    }
}

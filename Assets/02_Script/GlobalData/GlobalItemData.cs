using UnityEngine;
using System.Collections.Generic;

public class GlobalItemData : MonoBehaviour
{
    //딕셔너리로 구현 + serializable dictionary asset 사용하여 inspector에 띄우기
    public static Dictionary<string, int> itemData = new Dictionary<string, int>();

    //기본탄환
    public static string i_basic = "basic";
    public static int i_basic_Lv = 0;

    //범위 공격(성역)
    public static string i_holyarea = "holyarea";
    public static int i_holyarea_Lv = 0;

    //위성
    public static string i_satellite = "satellite";
    public static int i_satellite_Lv= 0;

    //근접 회전 번개
    public static string i_lightball = "lightball";
    public static int i_lightball_Lv = 0;

    //불 발사
    public static string i_flame = "flame";
    public static int i_flame_Lv = 0;

    public void Awake()
    {
        //itemData.Add(i_basic, i_basic_Lv);
        //itemData.Add(i_holyarea, i_holyarea_Lv);
        //itemData.Add(i_satellite, i_satellite_Lv);
        if(!itemData.ContainsKey(i_lightball))
        {
            itemData.Add(i_lightball, i_lightball_Lv);          
        }
        //itemData.Add(i_flame, i_flame_Lv);
    }
}

using UnityEngine;
using System.Collections.Generic;

public class GlobalItemData : MonoBehaviour
{
    //딕셔너리로 구현 + serializable dictionary asset 사용하여 inspector에 띄우기
    public static Dictionary<string, int> itemData = new Dictionary<string, int>();
    public static List<string> itemDescription = new List<string>();

    //기본탄환
    public static string i_basic = "basic";
    public static int i_basic_Lv = 0;
    public static string i_basic_discript = "basic 입니다.";

    //범위 공격(성역)
    public static string i_holyarea = "holyarea";
    public static int i_holyarea_Lv = 0;
    public static string i_holyarea_discript = "holyarea 입니다.";

    //위성
    public static string i_satellite = "satellite";
    public static int i_satellite_Lv= 0;
    public static string i_satellite_discript = "satellite 입니다.";

    //근접 회전 번개
    public static string i_lightball = "lightball";
    public static int i_lightball_Lv = 0;
    public static string i_lightball_discript = "lightball 입니다.";

    //불 발사
    public static string i_flame = "flame";
    public static int i_flame_Lv = 0;
    public static string i_flame_discript = "flame 입니다.";

    public void Awake()
    {
        Debug.Log("초기화");
        if (!itemData.ContainsKey(i_basic))
        {
            itemData.Add(i_basic, i_basic_Lv);
            itemDescription.Add(i_basic_discript);
        }

        
        if (!itemData.ContainsKey(i_holyarea))
        {
            itemData.Add(i_holyarea, i_holyarea_Lv);
            itemDescription.Add(i_holyarea_discript);
        }

        if (!itemData.ContainsKey(i_lightball))
        {
            itemData.Add(i_lightball, i_lightball_Lv);
            itemDescription.Add(i_lightball_discript);
        }

        //itemData.Add(i_flame, i_flame_Lv);
    }

    public static void TempRemoveFullLevel(string key)
    {
        itemData.Remove(key);
    }
}

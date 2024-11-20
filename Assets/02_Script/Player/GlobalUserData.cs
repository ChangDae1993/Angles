using UnityEngine;

public class GlobalUserData : MonoBehaviour
{
    public static float playerExp;

    public static int stage_Progress = 0;

    //레벨
    public static int p_Level = 0;

    //체력
    public static float p_HP;

    //체력 회복률
    public static float p_MP;

    //받는 피해량
    public static float p_Shield;

    //회피율
    public static float p_Dodge;

    //이동속도
    public static float p_MoveSpeed = 5f;

    //공격력
    public static float p_Attack;

    //치명타율
    public static float p_CriticalRate;

    //치명타 배율
    public static float p_CriticalDmg;

    //마법 쿨타임
    public static float p_FireRate;

    //축복 획득량
    public static float p_ExpAdd;

    //생명 구슬 회복량
    public static float p_HealAmount;

    //아이템 획득 반경
    public static float p_ItemGainRange;

    public void Start()
    {
        playerExp = 0.0f;
    }

}

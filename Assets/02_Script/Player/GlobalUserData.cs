using UnityEngine;

public class GlobalUserData : MonoBehaviour
{
    public static float playerExp;

    public static int stage_Progress = 0;

    //체력
    public static float p_HP;
    //체력 회복률
    public static float p_MP;
    //받는 피해량
    //회피율
    //이동속도
    public static float p_moveSpeed = 5f;
    //공격력
    //치명타율
    //치명타 배율
    //마법 쿨타임
    //축복 획득량
    //생명 구슬 회복량
    //아이템 획득 반경

    private void Start()
    {
        playerExp = 0.0f;
    }

}

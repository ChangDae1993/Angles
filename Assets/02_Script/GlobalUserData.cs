using UnityEngine;

public class GlobalUserData : MonoBehaviour
{
    public static int hpPotionNum = 10;

    public static float playerExp;

    public static int stage_Progress = 0;

    private void Start()
    {
        hpPotionNum = 5;
        playerExp = 0.0f;
    }

}

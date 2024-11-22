using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public float gameTime;
    private float maxGameTime = 2 * 10f;

    public EnemyPoolManager EnemyPoolManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.UM.stgCNt > (UIManager.stagecount)1)
        {
            gameTime += Time.deltaTime;

            if (gameTime > maxGameTime)
            {
                gameTime = maxGameTime;
            }
        }

    }


}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public float spawnTimer;

    public int stage_level;

    public SpawnData[] spawnData;

    public TextMeshProUGUI stageLv_txt;

    public Play_Timer play_timer;
    private EnemyPoolManager epm = null;

    private void Awake()
    {
        epm = GameManager.GM.GPM.EnemyPoolManager;
        epm.spawnPoint = this.transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameManager.GM.GPM.maxGameTime = (spawnData.Length) * 10f;
        stage_level = 0;
    }

    // Update is called once per frame
    public void Update()
    { 
        stage_level = Mathf.Min(Mathf.FloorToInt((play_timer.surviveTime-play_timer.timeRemaining) / 60f), spawnData.Length-1);
        stageLv_txt.text = "Current Stage : " +stage_level.ToString();
        spawnTimer += Time.deltaTime;

        if(spawnTimer > Random.Range(0, spawnData[stage_level].e_SpawnTime))
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = epm.Get(0);

        enemy.transform.position = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[stage_level]);
    }
}

[System.Serializable]
public class SpawnData
{
    //몬스터 색상
    public Color e_color;

    //몬스터 크기
    public float e_Scale;

    //소환주기
    public  float e_SpawnTime;

    //타입
    public  int e_Type;

    //체력
    public  float e_Hp;

    //속도
    public  float e_Speed;

    //경험치
    public float e_Exp;

    public float e_damage;
}

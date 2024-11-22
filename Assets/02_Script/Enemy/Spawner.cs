using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public float spawnTimer;

    public int stage_level;

    public SpawnData[] spawnData;

    [SerializeField] EnemyPoolManager epm = null;

    private void Awake()
    {
        epm = GameManager.GM.GPM.EnemyPoolManager;
        epm.spawnPoint = this.transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stage_level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        stage_level = Mathf.Min(Mathf.FloorToInt(GameManager.GM.GPM.gameTime / 10f), spawnData.Length-1);

        spawnTimer += Time.deltaTime;

        if(spawnTimer > spawnData[stage_level].e_SpawnTime)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = epm.Get(0);

        enemy.transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[stage_level]);
    }
}

[System.Serializable]
public class SpawnData
{
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

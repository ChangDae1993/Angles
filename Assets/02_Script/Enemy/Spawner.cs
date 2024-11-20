using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public float spawnTimer;

    private void Awake()
    {
        GameManager.GM.GPM.EnemyPoolManager.spawnPoint = this.transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > 0.2f)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = GameManager.GM.GPM.EnemyPoolManager.Get(Random.Range(0,1));

        enemy.transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;
    }
}

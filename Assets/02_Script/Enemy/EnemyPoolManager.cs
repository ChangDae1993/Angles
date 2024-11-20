using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolManager : MonoBehaviour
{
    public GameObject[] enemies;

    List<GameObject>[] pools;

    public Transform spawnPoint = null;

    private void Awake()
    {
        pools = new List<GameObject>[enemies.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject> ();
        }

        //Debug.Log(pools.Length);
    }

    //public void Start()
    //{

    //}

    public GameObject Get(int index)
    {

        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select)
        {
            if(spawnPoint != null)
            {
                select = Instantiate(enemies[index], spawnPoint);
            }
            pools[index].Add(select);
        }
        return select;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Player_State : MonoBehaviour
{
    public bool levelUp;    
    public void Awake()
    {
        if (GameManager.GM.player == null)
        {
            GameManager.GM.player = this.gameObject;
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void LevelUp()
    {
        Debug.Log("level up");
        levelUp = true;
    }

    public void Die()
    {

    }
}

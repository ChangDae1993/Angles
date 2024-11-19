using UnityEngine;
using UnityEngine.UI;

public class Player_State : MonoBehaviour
{
    public bool levelUp;

    public Image levelUpPanel;
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
        levelUpPanel.gameObject.SetActive(true);
        Debug.Log("level up");
        Time.timeScale = 0f;
        levelUp = true;
    }

    public void LevelUpSelect()
    {
        levelUpPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        levelUp = false;
    }

    public void Die()
    {

    }
}

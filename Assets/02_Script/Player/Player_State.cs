using TMPro;
using UnityEditor;
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
    //public void Update()
    //{
        
    //}


    public void LevelUp()
    {
        levelUpPanel.gameObject.SetActive(true);
        //Debug.Log("level up");
        Time.timeScale = 0f;
        levelUp = true;
    }

    public void LevelUpSelect(TextMeshProUGUI selectItem)
    {
        if (GlobalItemData.itemData.ContainsKey(selectItem.text))
        {
            if(GlobalItemData.itemData[selectItem.text] < 5)
            {
                GlobalItemData.itemData[selectItem.text]++;
            }
        }
        Debug.Log(selectItem.text + " : " + GlobalItemData.itemData[selectItem.text]);
        //Debug.Log("select");

        if(ResourceInCheck(selectItem.text))
        {
            GameObject prefab = Resources.Load<GameObject>(selectItem.text);

            // 2. 인스턴스화하여 씬에 배치
            GameObject instance = Instantiate(prefab);
            instance.name = prefab.name;
            instance.transform.SetParent(this.transform);
        }
        

        levelUpPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        levelUp = false;
    }

    public bool ResourceInCheck(string objectName)
    {
        Object resource = Resources.Load(objectName);
        return resource != null;
    }

    public void Die()
    {

    }
}

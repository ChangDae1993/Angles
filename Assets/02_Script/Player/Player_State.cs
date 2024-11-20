using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player_State : MonoBehaviour
{
    public bool levelUp;

    public Image levelUpPanel;

    [Space(10f)]
    [Header("Weapon List")]
    public List<GameObject> weaponList = new List<GameObject>();

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
            if (GlobalItemData.itemData[selectItem.text] < 5)
            {
                GlobalItemData.itemData[selectItem.text]++;
            }
            else
            {
                //만렙 dictionary에서 제외
                Debug.Log($"{selectItem} is at max level.");
            }
        }

        //선택 했는데 이미 가지고 있는지 확인 해야함
        // LINQ를 사용하여 검색
        GameObject existingObject = weaponList.FirstOrDefault(obj => obj.name == selectItem.text);


        if (existingObject == null)   //리스트에 없음 새로 instantiate하고 list에 string넣어주기
        {
            if (ResourceInCheck(selectItem.text))
            {
                GameObject prefab = Resources.Load<GameObject>(selectItem.text);
                // 2. 인스턴스화하여 씬에 배치
                GameObject instance = Instantiate(prefab);
                instance.name = prefab.name; // 오브젝트 이름 설정
                instance.transform.SetParent(this.transform);
                instance.transform.localScale = Vector3.one;

                weaponList.Add(instance);

                //현재 레벨 0 에서 1로 업데이트
                //%%%%%%규칙 : Level_Chkr_Script 가지고 있어야 함%%%%%%
                if(instance.gameObject.TryGetComponent(out Level_Chkr_Script lcs))
                {
                    //레벨을 넘겨 받아야함
                    lcs.levelChck(GlobalItemData.itemData[selectItem.text]);
                }
            }
        }
        else
        {
            // Level_Chkr_Script 컴포넌트가 있다면 레벨 업데이트
            if (existingObject.TryGetComponent(out Level_Chkr_Script lcs))
            {
                lcs.levelChck(GlobalItemData.itemData[selectItem.text]);
            }
        }

        Debug.Log(selectItem.text + " : " + GlobalItemData.itemData[selectItem.text]);
        //Debug.Log("select");





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

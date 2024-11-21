using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using static UnityEngine.GraphicsBuffer;

public class Player_State : MonoBehaviour
{
    [Header("Stat")]
    [Space(5f)]
    [Header("HP")]
    //최대 체력
    public float MaxHP;
    //체력
    public float HP;
    //체력 재생
    public float HP_Gen;
    //받는 피해량
    public float Shield;

    //레벨
    [Header("Level")]
    public int Level;
    //필요 경험치
    public float EXP;
    //현재 경험치
    public float cur_EXP;
    //경험치 UI
    public Image exp_Img;

    [Header("Level Up")]
    public bool levelUp;
    public Image levelUpPanel;

    [Header("Dodge")]
    //회피율
    public float Dodge;

    [Header("Speed")]
    //이동속도
    public  float MoveSpeed;

    [Header("Attack")]
    //공격력
    public  float Attack;
    //치명타율
    public float CriticalRate;
    //치명타 배율
    public float CriticalDmg;
    //마법 쿨타임
    public float FireRate;

    [Header("Plus Stat")]
    //축복 획득량
    public float ExpAdd;
    //생명 구슬 회복량
    public float HealAmount;
    //아이템 획득 반경
    public float ItemGainRange;


    [Space(10f)]
    [Header("Weapon List")]
    public List<GameObject> weaponList = new List<GameObject>();

    public void Awake()
    {
        Debug.Log("player Start");
        if (GameManager.GM.player == null)
        {
            GameManager.GM.player = this.gameObject;
        }

        if (GameManager.GM.player_state == null)
        {
            GameManager.GM.player_state = this;
        }
        Init();
    }

    public void Init()
    {
        MaxHP += GlobalUserData.p_HP;
        HP += MaxHP;
        HP_Gen += GlobalUserData.p_HPGen;
        Level = 0;
        Shield += GlobalUserData.p_Shield;
        Dodge += GlobalUserData.p_Dodge;
        MoveSpeed += GlobalUserData.p_MoveSpeed;
        Attack += GlobalUserData.p_Attack;
        CriticalRate += GlobalUserData.p_CriticalRate;
        CriticalDmg += GlobalUserData.p_CriticalDmg;
        FireRate += GlobalUserData.p_FireRate;
        ExpAdd += GlobalUserData.p_ExpAdd;
        HealAmount += GlobalUserData.p_HealAmount;
        ItemGainRange += GlobalUserData.p_ItemGainRange;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if(cur_EXP >= EXP)
        {
            LevelUp();
        }
    }

    public void NewGameLevelUp()
    {
        //레벨업 후 경험치 계산
        Level++;
        if (ResourceInCheck("basic"))
        {
            GameObject prefab = Resources.Load<GameObject>("basic");

            // 2. 인스턴스화하여 씬에 배치
            GameObject instance = Instantiate(prefab);
            instance.name = prefab.name; // 오브젝트 이름 설정
            instance.transform.SetParent(this.transform);
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localScale = Vector3.one;


            //현재 레벨 0 에서 1로 업데이트
            //%%%%%%규칙 : Level_Chkr_Script 가지고 있어야 함%%%%%%
            if (instance.gameObject.TryGetComponent(out Level_Chkr_Script lcs))
            {
                //레벨을 넘겨 받아야함
                lcs.levelChck(GlobalItemData.itemData["basic"]);
            }
        }


        //기본 무기 제공
    }


    public void LevelUp()
    {
        //레벨업 후 경험치 계산
        Level++;
        cur_EXP = 0f;
        EXP = Level * EXP;

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

                //Debug.Log(selectItem.text + " : " + GlobalItemData.itemData[selectItem.text]);
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

        if (levelUpPanel.TryGetComponent(out LevelUpPanel_Script lps))
        {
            if (lps.randomitemsLv.Count > 0 && lps.randomitems.Contains(selectItem.text))
            {
                int index = lps.randomitems.IndexOf(selectItem.text);
                lps.randomitemsLv[index]++;
                Debug.Log(lps.randomitemsLv[index]);
            }
        }

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

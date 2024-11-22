using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel_Script : MonoBehaviour
{
    [Header("OnOffDirection")]
    public Image BG;

    public Button randomItem_1;
    public TextMeshProUGUI randomItem_1_txt;
    public TextMeshProUGUI randomItem_1_lv_txt;
    [Space(10f)]
    public Button randomItem_2;
    public TextMeshProUGUI randomItem_2_txt;
    public TextMeshProUGUI randomItem_2_lv_txt;
    [Space(10f)]
    public Button randomItem_3;
    public TextMeshProUGUI randomItem_3_txt;
    public TextMeshProUGUI randomItem_3_lv_txt;
    [Space(10f)]
    public Button randomItem_4;
    public TextMeshProUGUI randomItem_4_txt;
    public TextMeshProUGUI randomItem_4_lv_txt;

    public List<string> randomitems;
    public List<int> randomitemsLv;

    public void Awake()
    {
        //Debug.Log("Level Check");
        randomitems = new List<string>(GlobalItemData.itemData.Keys);
        randomitemsLv = new List<int>(GlobalItemData.itemData.Values);
    }

    public void LevelUpPanelOFF(bool onoff)
    {
        if (randomitems.Count <= 0)
        {
            Debug.LogError("다 업글 했시요");
            Debug.Log(Time.timeScale);

            return;
        }
        else
        {
            if (onoff)   //켜기
            {
                Time.timeScale = 0f;
                BG.enabled = true;
                randomItem_1.gameObject.SetActive(true);
                randomItem_2.gameObject.SetActive(true);
                randomItem_3.gameObject.SetActive(true);
                randomItem_4.gameObject.SetActive(true);

                GEtRandomItem(randomItem_1_txt, randomItem_1_lv_txt);
                GEtRandomItem(randomItem_2_txt, randomItem_2_lv_txt);
                GEtRandomItem(randomItem_3_txt, randomItem_3_lv_txt);
                GEtRandomItem(randomItem_4_txt, randomItem_4_lv_txt);
            }
            else        //끄기
            {
                Time.timeScale = 1f;
                BG.enabled = false;
                randomItem_1.gameObject.SetActive(false);
                randomItem_2.gameObject.SetActive(false);
                randomItem_3.gameObject.SetActive(false);
                randomItem_4.gameObject.SetActive(false);
            }
        }

    }

    private void Start()
    {
        
    }
    private void OnDisable()
    {
        //Debug.Log("Off");
    }

    [HideInInspector] public int randomIt;

    public void GEtRandomItem(TextMeshProUGUI itemText, TextMeshProUGUI itemLvText)
    {
        randomIt = Random.Range(0, randomitems.Count);
        if (randomitems.Count <= 0)
        {
            Debug.LogError("다 업글 했시요");
            return;
        }
        else
        {

            itemText.text = randomitems[randomIt];
            itemLvText.text = "Lv :" + randomitemsLv[randomIt].ToString();

            //if (randomitemsLv[randomIt] > 4)
            //{
            //    Debug.Log(randomitems[randomIt] + " : 만렙  data개수 ==" + GlobalItemData.itemData.Count);
            //    GlobalItemData.TempRemoveFullLevel(randomitems[randomIt]);
            //    randomitems.Remove(randomitems[randomIt]);
            //    randomitemsLv.Remove(randomitemsLv[randomIt]);
            //}
            //else
            //{
            //    itemText.text = randomitems[randomIt];
            //    itemLvText.text = "Lv :" + randomitemsLv[randomIt].ToString();
            //}
        }

        //Debug.Log(itemLvText.text);
    }

    //public void ItemDiscript()
    //{
    //    if(GlobalItemData.itemData.ContainsKey(randomItem_1_txt.text))
    //    {
    //        ICollection<string> keys = GlobalItemData.itemData.Keys;
    //        //Debug.Log(GlobalItemData.itemData[randomItem_1_txt.text]);  //이건 당연히 0이지
    //        //Debug.Log(randomitems[randomIt]);

    //        foreach (string key in keys)
    //        {
    //            if(key == randomItem_1_txt.text)
    //            {
    //                Debug.Log(key);
    //                Debug.Log(GlobalItemData.itemData[key]);
    //            }
    //        }

    //        //GlobalItemData.itemDescription[GlobalItemData.itemData[randomItem_1_txt.text]] = "d";
    //        //Debug.Log(GlobalItemData.itemDescription[GlobalItemData.itemData[randomItem_1_txt.text]]);
            
    //    }
    //}
}

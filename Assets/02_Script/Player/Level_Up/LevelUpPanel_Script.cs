using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel_Script : MonoBehaviour
{
    public Button randomItem_1;
    public TextMeshProUGUI randomItem_1_txt;
    public TextMeshProUGUI randomItem_1_lv_txt;
    //[Space(10f)]
    //public Button randomItem_2;
    //public TextMeshProUGUI randomItem_2_txt;
    //public TextMeshProUGUI randomItem_2_lv_txt;
    //[Space(10f)]
    //public Button randomItem_3;
    //public TextMeshProUGUI randomItem_3_txt;
    //public TextMeshProUGUI randomItem_3_lv_txt;
    //[Space(10f)]
    //public Button randomItem_4;
    //public TextMeshProUGUI randomItem_4_txt;
    //public TextMeshProUGUI randomItem_4_lv_txt;

    List<string> randomitems = new List<string>(GlobalItemData.itemData.Keys);
    List<int> randomitemsLv = new List<int>(GlobalItemData.itemData.Values);


    private void OnEnable()
    {
        //randomItem_1_txt.text = GetRandomItem();
        //randomItem_2_txt.text = GetRandomItem();
        //randomItem_3_txt.text = GetRandomItem();
        //randomItem_4_txt.text = GetRandomItem();

        GEtRandomItem(randomItem_1_txt, randomItem_1_lv_txt);
        //GEtRandomItem(randomItem_2_txt, randomItem_2_lv_txt);
        //GEtRandomItem(randomItem_3_txt, randomItem_3_lv_txt);
        //GEtRandomItem(randomItem_4_txt, randomItem_4_lv_txt);
    }

    private void OnDisable()
    {
        Debug.Log("Off");
    }

    int randomIt;
    public void GEtRandomItem(TextMeshProUGUI itemText, TextMeshProUGUI itemLvText)
    {
        randomIt = Random.Range(0, randomitems.Count);
        itemText.text =  randomitems[randomIt];
        itemLvText.text = "Lv :" + randomitemsLv[randomIt].ToString();
        //Debug.Log(randomitemsLv[randomIt]);
    }


    //public string GetRandomItem()
    //{
    //    randomIt = Random.Range(0, randomitems.Count);
    //    return randomitems[randomIt];
    //}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}

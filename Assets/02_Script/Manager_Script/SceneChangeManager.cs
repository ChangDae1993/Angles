using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeManager : MonoBehaviour
{
    public Image sceneChngPanel;

    Coroutine sceneChng;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(sceneChng != null)
        {
            StopCoroutine(sceneChng);
            sceneChng = StartCoroutine(changeSceneFadeInCO());
        }
        else
        {
            sceneChng = StartCoroutine(changeSceneFadeInCO());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator changeSceneFadeInCO()
    {
        while (sceneChngPanel.color.a > 0f)
        {
            sceneChngPanel.color = new Color(0f, 0f, 0f, sceneChngPanel.color.a - 0.1f);
            yield return new WaitForSeconds(0.1f);
        }

        sceneChngPanel.color = new Color(0f, 0f, 0f, 0f);
    }

    public IEnumerator changeSceneFadeOutCO()
    {
        //다음 씬으로 넘어가기
        while (sceneChngPanel.color.a < 1f)
        {
            sceneChngPanel.color = new Color(0f, 0f, 0f, sceneChngPanel.color.a + 0.05f);
            yield return new WaitForSeconds(0.1f);
        }

        sceneChngPanel.color = new Color(0f, 0f, 0f, 1f);
    }

    public void ChangeScene(int SceneIndex)
    {
        sceneChngPanel.color = new Color(0f, 0f, 0f, 1f);
        if (sceneChng != null)
        {
            StopCoroutine(sceneChng);
            sceneChng = StartCoroutine(changeSceneFadeInCO());
        }
        else
        {
            sceneChng = StartCoroutine(changeSceneFadeInCO());
        }

        GameManager.GM.UM.stgCNt = (UIManager.stagecount)SceneIndex;
        SceneManager.LoadScene(SceneIndex);
    }

    public void ToIntroScene()
    {
        //sceneChng = StartCoroutine(changeSceneFadeOutCO());
        sceneChngPanel.color = new Color(0f, 0f, 0f, 1f);
        GameManager.GM.UM.stgCNt = UIManager.stagecount.IntroScene;
        GameManager.GM.UM.BtnGroup.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}

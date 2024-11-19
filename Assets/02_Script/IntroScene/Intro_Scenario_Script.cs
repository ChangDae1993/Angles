using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Intro_Scenario_Script : MonoBehaviour
{
    public int textindex = 0;

    public Text[] storyTexts;

    Coroutine sceneChange;
    Coroutine textShow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneChange = StartCoroutine(GameManager.GM.SCM.changeSceneFadeInCO());

        if (textShow != null)
        {
            StopCoroutine(textShow);
            textShow = StartCoroutine(textShowCo());
        }
        else
        {
            textShow = StartCoroutine(textShowCo());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            if (textindex < storyTexts.Length -1)
            {

                storyTexts[textindex].enabled = false;
                textindex++;
                storyTexts[textindex].enabled = true;

                if (textShow != null)
                {
                    StopCoroutine(textShow);
                    textShow = StartCoroutine(textShowCo());
                }
                else
                {
                    textShow = StartCoroutine(textShowCo());
                }
            }
            else
            {
                GameManager.GM.SCM.ChangeScene(2);
            }
        }
    }

    [Header("text direction")]
    public float fadeInTime;
    private float colortextAlpha = 0f;
    public IEnumerator textShowCo()
    {
        colortextAlpha = 0f;
        while (storyTexts[textindex].color.a < 255f)
        {
            //Debug.Log("Fade In ");
            colortextAlpha += fadeInTime;
            storyTexts[textindex].color = new Color(0f, 0f, 0f, colortextAlpha);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

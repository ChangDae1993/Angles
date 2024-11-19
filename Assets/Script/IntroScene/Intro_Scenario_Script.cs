using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Intro_Scenario_Script : MonoBehaviour
{
    public int textindex = 0;

    public Text[] storyTexts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    Coroutine textShow;
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                Debug.Log("no mouse");
                return;
            }

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
                Debug.Log("Next Scene Go");
            }


        }
    }

    [Header("text direction")]
    public float fadeInTime;
    public float fadeOutTime;
    public float colorAlpha = 0f;
    public IEnumerator textShowCo()
    {
        colorAlpha = 0f;
        while (storyTexts[textindex].color.a < 255f)
        {
            Debug.Log("Fade In ");
            colorAlpha += fadeInTime;
            storyTexts[textindex].color = new Color(0f, 0f, 0f, colorAlpha);
            yield return new WaitForSeconds(0.1f);
        }


        //yield return new WaitForSeconds(fadeOutTime);
    }
}

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
        if(sceneChange != null)
        {
            StopCoroutine(sceneChange);
            sceneChange = StartCoroutine(ScenechngCo(true));
        }
        else
        {
            sceneChange = StartCoroutine(ScenechngCo(true));
        }


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
        if(Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                //Debug.Log("no mouse");
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
                if (sceneChange != null)
                {
                    StopCoroutine(sceneChange);
                    sceneChange = StartCoroutine(ScenechngCo(false));
                }
                else
                {
                    sceneChange = StartCoroutine(ScenechngCo(false));
                }
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

    public Image SceneCHNGpanel;
    [SerializeField] private float colorPanelAlpha = 255f;
    private float fadetime = 0.5f;
    public IEnumerator ScenechngCo(bool onoff)
    {
        if(onoff)
        {

            while (colorPanelAlpha > 0f)
            {
                colorPanelAlpha -= fadetime;
                SceneCHNGpanel.color = new Color(0f, 0f, 0f, colorPanelAlpha);
                Debug.Log(colorPanelAlpha);
                yield return new WaitForSeconds(0.1f);
            }

            SceneCHNGpanel.color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            //다음 씬으로 넘어가기
            colorPanelAlpha = 0f;
            while (colorPanelAlpha < 255f)
            {
                SceneCHNGpanel.color = new Color(0f, 0f, 0f, colorPanelAlpha);
                yield return new WaitForSeconds(0.1f);
            }

            SceneCHNGpanel.color = new Color(0f, 0f, 0f, 255f);
            Debug.Log("Next Scene Go");
        }

        yield return null;
    }
}

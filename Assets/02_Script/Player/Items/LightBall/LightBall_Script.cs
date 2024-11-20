using UnityEngine;

public class LightBall_Script : MonoBehaviour
{
    public GameObject circles1;
    public GameObject circles2;
    public GameObject circles3;
    public GameObject circles4;

    private void Awake()
    {
        circles1.gameObject.SetActive(false);
        circles2.gameObject.SetActive(false);
        circles3.gameObject.SetActive(false);
        circles4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * 300f * Time.deltaTime);
    }

    public void Upgrade(int level)
    {
        if (level == 1)
        {
            circles1.gameObject.SetActive(true);
        }
        else if (level == 2)
        {
            circles2.gameObject.SetActive(true);
        }
        else if(level == 3)
        {
            circles3.gameObject.SetActive(true);
        }
        else if( level == 4)
        {
            circles4.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log(level + "checck");
        }

    }
}

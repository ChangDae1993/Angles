using UnityEngine;

public class LightBall_Script : MonoBehaviour
{
    public GameObject[] circles;
    //public GameObject circles1;
    //public GameObject circles2;
    //public GameObject circles3;
    //public GameObject circles4;

    private void Awake()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            circles[i].gameObject.SetActive(false);
        }

        //circles1.gameObject.SetActive(false);
        //circles2.gameObject.SetActive(false);
        //circles3.gameObject.SetActive(false);
        //circles4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * 300f * Time.deltaTime);
    }

    public void Upgrade(int level)
    {
        for (int i = 0; i < level; i++)
        {
            float angle = i * (Mathf.PI * 2.0f) / level;

            GameObject child = circles[i];
            child.gameObject.SetActive(true);
            child.transform.position
                = transform.position + (new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0)) * 2;
        }

        //if (level == 1)
        //{
        //    circles1.gameObject.SetActive(true);
        //}
        //else if (level == 2)
        //{
        //    circles2.gameObject.SetActive(true);
        //}
        //else if(level == 3)
        //{
        //    circles3.gameObject.SetActive(true);
        //}
        //else if( level == 4)
        //{
        //    circles4.gameObject.SetActive(true);
        //}
        //else
        //{
        //    Debug.Log(level + "checck");
        //}
            Debug.Log(level + "checck");

    }
}

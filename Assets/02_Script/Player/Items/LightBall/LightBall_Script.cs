using UnityEngine;

public class LightBall_Script : MonoBehaviour
{
    public GameObject[] circles;
    public float rotateSpeed;

    private void Awake()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            circles[i].gameObject.SetActive(false);
        }
        rotateSpeed = 120;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    public void Upgrade(int level)
    {
        if (level > 4)
            return;

        rotateSpeed += (rotateSpeed* 0.1f);

        for (int i = 0; i < level; i++)
        {
            float angle = i * (Mathf.PI * 2.0f) / level;

            GameObject child = circles[i];
            child.gameObject.SetActive(true);
            child.transform.position
                = transform.position + (new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0)) * 1.5f;
        }
        Debug.Log(level + "checck");
    }
}

using UnityEngine;

public class LightBall_Script : MonoBehaviour
{
    //public GameObject circles;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * 300f * Time.deltaTime);
    }
}

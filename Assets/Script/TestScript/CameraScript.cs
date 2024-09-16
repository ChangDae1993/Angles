using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject playerTarget;
    public Vector3 followPos;
    public float camSize;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        followPos = new Vector3(playerTarget.transform.position.x, 
            playerTarget.transform.position.y,
            -30f);

        Camera.main.orthographicSize = camSize;

        this.transform.position = followPos;
    }
}

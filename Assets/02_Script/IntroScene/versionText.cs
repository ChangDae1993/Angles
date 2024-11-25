using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class versionText : MonoBehaviour
{

    public Text versionTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        versionTxt.text = "ver." + Application.version.ToString() + " Test_Build";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class holyarea_Script : MonoBehaviour
{


    public void Upgrade(int level)
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && collision.gameObject.TryGetComponent(out Enemy enemy))
        {

        }
    }

}

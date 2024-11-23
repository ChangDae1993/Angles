using UnityEngine;

public class max_level_text_Script : MonoBehaviour
{
    public Animator animator;
    public void OnEnable()
    {
        animator.SetBool("on", true);
    }

    public void OnDisable()
    {
        animator.SetBool("on", false);
    }

    public void OffObj()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}

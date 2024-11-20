using System.Collections;
using UnityEngine;

public class item_basic_script : MonoBehaviour
{
    public float damage;
    public int piearcing;
    public Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.piearcing = per;

        if(per > -1)
        {
            rigid.linearVelocity = dir;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || piearcing < -1)
            return;

        piearcing--;

        if(piearcing == -1)
        {
            rigid.linearVelocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

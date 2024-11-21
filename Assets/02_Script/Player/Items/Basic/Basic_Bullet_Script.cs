using System.IO;
using UnityEngine;

public class Basic_Bullet_Script : MonoBehaviour
{
    public float damage;
    public bool bulletOn;
    Rigidbody2D rigid;

    public int piearcing;
    public int curPiearcing;

    private void OnEnable()
    {
        Shoot();
        curPiearcing = piearcing;
        bulletOn = true;
    }

    private void OnDisable()
    {
        //Debug.Log("false");
        bulletOn = false;
    }

    private void Awake()
    {
        piearcing = 0;  //업그레이드 하면 바뀐다

        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

    }

    float lifeTime;
    // Update is called once per frame
    public void Update()
    {
        lifeTime += Time.deltaTime;
        if(bulletOn && lifeTime > 2f)
        {
            lifeTime = 0;
            this.gameObject.SetActive(false);
        }

    }

    public void Shoot()
    {
        //Debug.Log("Shoot");
    }

    //public void Fire()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") || curPiearcing == -1)
            return;
        else if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            curPiearcing--;
            enemy.TakeDamage(damage);

            //Debug.Log("Enemy");
            if (curPiearcing <= 0)
            {
                rigid.linearVelocity = Vector2.zero;
                gameObject.SetActive(false);
            }
        }
    }
}

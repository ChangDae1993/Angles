using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 0f;
    public float Hp = 0f;
    public float maxHP = 0f;
    public Sprite[] sprites;


    public Rigidbody2D target;

    [SerializeField] private bool islive;

    public Rigidbody2D rigid;
    public SpriteRenderer spriteRen;

    private void Awake()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        spriteRen = this.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        target = GameManager.GM.player.GetComponent<Rigidbody2D>();
        islive = true;

        Hp = maxHP;
    }

    public void Init(SpawnData data)
    {
        spriteRen.sprite = sprites[data.e_Type];
        Speed = data.e_Speed;
        maxHP = data.e_Hp;
        Hp = data.e_Hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (!islive)
            return;

        Vector2 targerDIr = target.position - rigid.position;
        Vector2 nextVec = targerDIr.normalized * Speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = Vector2.zero;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    #region spriteFLip

    //private void LateUpdate()
    //{
    //    if (!islive)
    //        return;

    //    //������ false, ũ�� true
    //    spriteRen.flipX = target.position.x < rigid.position.x;
    //}

    #endregion
}

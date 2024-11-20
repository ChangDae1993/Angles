using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0f;
    public Rigidbody2D target;

    public bool islive = false;

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
        Vector2 nextVec = targerDIr.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = Vector2.zero;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

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

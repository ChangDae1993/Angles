using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionScript : MonoBehaviour
{
    Collider2D col;
    public Player_Move p_move;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        p_move = GameManager.GM.player.GetComponent<Player_Move>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            //Debug.Log("No Out");
            return;
        }

        Vector3 playerPos = GameManager.GM.player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = p_move.inputVec;

        //float dirX = playerDir.x < 0 ? -1 : 1;
        //float dirY = playerDir.y < 0 ? -1 : 1;

        float dirX = 0f;
        float dirY = 0f;

        if(playerDir.x < 0)
        {
            dirX = -1f;
        }
        else
        {
            dirX = 1f;
        }

        if (playerDir.y < 0)
        {
            dirY = -1f;
        }
        else
        {
            dirY = 1f;
        }

        switch (this.transform.tag)
        {
            case "Ground":
                if(diffX > diffY)
                {
                    this.transform.Translate(Vector3.right * dirX * 40);
                }
                else if(diffX < diffY)
                {
                    this.transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                if(col.enabled)
                {
                    this.transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f), 0f));
                }
                break;
            case "Item":
                //������ ���� �� ��ġ ���� ���� ������ �Ű� �ֱ�
                //������ ��ũ��Ʈ�� type���� �ٸ��� ����
                //if(this.TryGetComponent(out /*�����۽�ũ��Ʈ*/ type))
                //{
                //    switch()
                //        case "":
                //        break;
                //}

                break;
            default:
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionScript : MonoBehaviour
{
    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
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

        Vector3 playerDir = GameManager.GM.player.inputVec;

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
                //아이템 생길 시 위치 일정 수준 지나면 옮겨 주기
                break;
            default:
                break;
        }
    }
}

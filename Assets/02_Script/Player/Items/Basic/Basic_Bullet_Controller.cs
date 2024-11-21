using UnityEngine;

public class Basic_Bullet_Controller : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;

    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    public float fireTimer;

    public int pre_bullet_num;
    public GameObject[] bullets;

    private void Awake()
    {
        bullets = new GameObject[pre_bullet_num];

        for (int i = 0; i < pre_bullet_num; i++)
        {

            GameObject prefab = Resources.Load<GameObject>("Basic_Bullet");
            GameObject instance = Instantiate(prefab);
            instance.name = prefab.name; // 오브젝트 이름 설정
            instance.transform.SetParent(this.transform);

            instance.transform.localScale = Vector3.one;
            bullets[i] = instance;
            instance.gameObject.SetActive(false);
        }
        // 2. 인스턴스화하여 씬에 배치
    }


    public void Upgrade()
    {

    }

    public void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(this.transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    public void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer > GameManager.GM.player_state.FireRate)
        {
            fireTimer = 0f;
            Fire();

        }
    }

    public int bulletIndex = 0;
    public void Fire()
    {
        if (bulletIndex < bullets.Length) 
        {
            bullets[bulletIndex].gameObject.SetActive(true);
            bullets[bulletIndex].transform.position = this.transform.position;
            bulletIndex++;
        }
        else
        {
            bulletIndex = 0;
        }

        if (nearestTarget == null)
            return;
        else
        {
            Vector3 targetpos = nearestTarget.position;
            Vector3 dir = targetpos - transform.position;
            dir = dir.normalized;


            //Transform bullet = null;

            //오브젝트 풀에서 가져오기
            //bullet.position = transform.position;
            //bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            //bullet.GetComponent<Rigidbody2D>().linearVelocity = dir;
        }
    }


    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;

            float curDIff = Vector3.Distance(myPos, targetPos);

            if (curDIff < diff)
            {
                diff = curDIff;
                result = target.transform;
            }
        }
        return result;
    }
}

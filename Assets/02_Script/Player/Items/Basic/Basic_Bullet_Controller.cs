using UnityEngine;

public class Basic_Bullet_Controller : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;

    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    public float fireTimer;

    [Header("Bullet")]
    public int pre_bullet_num;
    public GameObject[] bullets;
    public int bulletIndex = 0;
    public float bulletSpeed;


    private void Awake()
    {
        bullets = new GameObject[pre_bullet_num];

        for (int i = 0; i < pre_bullet_num; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("Basic_Bullet");
            GameObject instance = Instantiate(prefab);
            instance.name = prefab.name; // 오브젝트 이름 설정
            instance.transform.SetParent(this.transform);
            // 2. 인스턴스화하여 씬에 배치
            instance.transform.localScale = Vector3.one;
            bullets[i] = instance;
            instance.gameObject.SetActive(false);
        }

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
    public void Fire()
    {
        if (nearestTarget == null)
            return;
        else
        {
            if (bulletIndex < bullets.Length)
            {
                bullets[bulletIndex].gameObject.SetActive(true);
                bullets[bulletIndex].transform.position = this.transform.position;

                Vector3 targetpos = nearestTarget.position;
                Vector2 dir = (targetpos - transform.position).normalized;

                bullets[bulletIndex].transform.rotation = Quaternion.LookRotation(dir);

                //Transform bullet = null;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                //오브젝트 풀에서 가져오기
                bullets[bulletIndex].transform.rotation = Quaternion.Euler(0, 0, angle);
                bullets[bulletIndex].GetComponent<Rigidbody2D>().linearVelocity = dir * bulletSpeed;
                bulletIndex++;
            }
            else
            {
                bulletIndex = 0;
            }

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

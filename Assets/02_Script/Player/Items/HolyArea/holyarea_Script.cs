using UnityEngine;

public class holyarea_Script : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public float damageArea;
    [SerializeField] private CircleCollider2D thisRange;
    public float areaCal;
    public float damageRate;
    public float damageTimer;

    public void Upgrade(int level)
    {

    }

    private void Awake()
    {
        thisRange = GetComponent<CircleCollider2D>();
        damageRate = 0.5f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer >= damageRate)
        {
            damageTimer = 0f;
            GiveAreaDamage();
        }
    }

    private void FixedUpdate()
    {
        damageArea = this.transform.localScale.x * areaCal;

        targets = Physics2D.CircleCastAll(this.transform.position, damageArea, Vector2.zero, 0, targetLayer);
    }


    int segments = 36;
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 center = this.transform.position;

        // 원을 세그먼트로 나눠 점을 계산
        float angleStep = 360f / segments;
        Vector3 previousPoint = center + new Vector3(damageArea, 0, 0);

        for (int i = 1; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad; // 각도를 라디안으로 변환
            Vector3 newPoint = center + new Vector3(Mathf.Cos(angle) * damageArea, Mathf.Sin(angle) * damageArea, 0);

            // 이전 점과 현재 점을 연결
            Gizmos.DrawLine(previousPoint, newPoint);
            previousPoint = newPoint;
        }
    }

    public void GiveAreaDamage()
    {
        foreach (RaycastHit2D target in targets)
        {
            if(target.transform.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
                Debug.Log(targets.Length);
            }
        }
    }
}

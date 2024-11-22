using UnityEngine;
using UnityEngine.UIElements;

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

    private float rotateAngle;
    public float rotateSpeed;

    public Quaternion rotate;

    [Header("Spark Animation")]
    public SpriteRenderer spriteRen;
    public Animator sparkAnim;

    public void Upgrade(int level)
    {
        damageRate -= 0.3f;
        this.transform.localScale = new Vector3(
            this.transform.localScale.x + 0.3f,
            this.transform.localScale.y + 0.3f,
            this.transform.localScale.z + 0.3f);

        rotateSpeed *= 0.8f;
    }

    private void Awake()
    {
        thisRange = GetComponent<CircleCollider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 초기 회전 값 저장
        rotateAngle = this.transform.localRotation.eulerAngles.z;
    }

    // Update is called once per frame
    public void Update()
    {
        // 회전 각도를 감소
        rotateAngle -= Time.deltaTime * rotateSpeed;

        // 새로운 회전 값을 Quaternion으로 적용
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotateAngle);


        // 색상 변화: damageTimer가 damageRate에 가까워질수록 노란색으로
        float colorProgress = Mathf.Clamp01(damageTimer / damageRate);
        spriteRen.color = Color.Lerp(Color.white, Color.yellow, colorProgress);

        damageTimer += Time.deltaTime;
        if (damageTimer >= damageRate)
        {
            damageTimer = 0f;
            GiveAreaDamage();

            spriteRen.color = Color.white;
            // 애니메이션 재생
            if (sparkAnim != null)
            {
                //sparkAnim.Play("spark");
                sparkAnim.SetTrigger("Play");
            }
        }

        //애니메이션 추가하기

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
                //Debug.Log(targets.Length);
            }
        }
    }
}

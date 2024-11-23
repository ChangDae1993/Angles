using UnityEngine;

public class light_ball_Script : MonoBehaviour
{
    public float damage;

    public Animator ballAnim;

    public void OnEnable()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            //Debug.Log("enemy");
            enemy.TakeDamage(damage);
        }
    }
}

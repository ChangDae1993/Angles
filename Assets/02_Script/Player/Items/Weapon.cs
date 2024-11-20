using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public int pier;

    public void Init(float damage, int pier)
    {
        this.damage = damage;
        this.pier = pier;
    }
}

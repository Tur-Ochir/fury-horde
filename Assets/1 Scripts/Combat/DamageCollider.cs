using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public float damage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
    }
}

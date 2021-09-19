using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] bool _dieOnAnyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out Bullet bullet))
            {
                _health.TakeDamage(1);
            }
        }

        if (_dieOnAnyCollision)
        {
            _health.TakeDamage(10000);
        }
    }
}
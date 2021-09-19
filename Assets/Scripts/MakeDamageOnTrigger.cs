using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out PlayerHealth health))
            {
                health.TakeDamage(_damageValue);
            }
        }
    }
}
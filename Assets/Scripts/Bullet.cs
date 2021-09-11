using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitParticle;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter()
    {
        Instantiate(_hitParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
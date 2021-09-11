using UnityEngine;

public class BodyLook : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerp;

    private void Update()
    {
        float rotationY = _target.position.x - transform.position.x > 0 ? rotationY = -45f : rotationY = 45f;
        transform.rotation =
            Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, rotationY, 0f), Time.deltaTime * _lerp);
    }
}
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpRate;
    [SerializeField] private bool _lerp;

    private void LateUpdate()
    {
        if (_lerp)
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRate);
        else
            transform.position = _target.position;
    }
}
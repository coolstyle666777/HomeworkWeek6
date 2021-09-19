using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _playerCamera;

    private void LateUpdate()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        
        plane.Raycast(ray, out float distance);
        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;
        
        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
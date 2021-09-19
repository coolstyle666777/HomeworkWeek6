using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _colliderTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _maxSpeed;

    private bool _grounded;
    private Vector2 _input;

    private void Update()
    {
        float compressY = 1f;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || _grounded == false)
        {
            compressY = 0.5f;
        }

        _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, compressY, 1f),
            Time.deltaTime * 15f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                _rigidbody.AddForce(0f, _jumpSpeed, 0f, ForceMode.VelocityChange);
            }
        }

        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (_grounded == false)
        {
            speedMultiplier = 0.2f;

            if (Mathf.Abs(_rigidbody.velocity.x) > _maxSpeed && Mathf.Abs(_input.x) > 0)
            {
                speedMultiplier = 0;
            }
        }
        
        _rigidbody.AddForce(_input.x * _moveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
        if (_grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45)
            {
                _grounded = true;
            }
        }
    }

    private void OnCollisionExit()
    {
        _grounded = false;
    }
}
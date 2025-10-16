using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController CharacterController;

    private float _moveSpeed = 5f;
    private float _runSpeed = 8f;
    private float _crouchSpeed = 4f;
    private float _jumpHeight = 1.5f;
    private float _gravity = -9.81f;

    private float _speed;
    private float _originalHeight;
    private bool _isGrounded;

    private Vector3 _velocity;

    private void Start()
    {
        _originalHeight = CharacterController.height;
    }

    private void Update()
    {
        _isGrounded = CharacterController.isGrounded;

        if (_isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        Move();
        ApplyGravity();
        Jump();
    }

    private void Move()
    {
        float _moveX = Input.GetAxis("Horizontal");
        float _moveZ = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);

        if (isCrouching)
        {
            _speed = _crouchSpeed;
            CharacterController.height = _originalHeight / 2f;
        }
        else
        {
            _speed = isRunning ? _runSpeed : _moveSpeed;
            CharacterController.height = _originalHeight;
        }

        Vector3 move = (transform.right * _moveX + transform.forward * _moveZ).normalized * _speed;
        CharacterController.Move(move * Time.deltaTime);
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
    }

    private void ApplyGravity()
    {
        _velocity.y += _gravity * Time.deltaTime;
        CharacterController.Move(_velocity * Time.deltaTime);
    }
}

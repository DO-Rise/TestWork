using System.Collections;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;

    private float _speed = 8f;
    private float _jumpForce = 5f;

    private float moveX;
    private int _jumpCount = 0;

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.01f)
            _jumpCount = 0;

        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);

            _jumpCount++;
        }

        Animation();

        if (moveX < 0f)
            _sprite.flipX = true;
        else if (moveX > 0f)
            _sprite.flipX = false;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(moveX * _speed, _rigidbody2D.velocity.y);
    }

    private void Animation()
    {
        if (_rigidbody2D.velocity.y > 0.01f)
        {
            if (_jumpCount == 1)
                _animator.SetTrigger("Jump");
            else if (_jumpCount == 2)
                _animator.SetTrigger("DoubleJump");
        }
        else if (_rigidbody2D.velocity.y < -0.01f)
        {
            _animator.SetTrigger("Fall");
        }
        else
        {
            if (moveX != 0f)
                _animator.Play("Run");
            else
                _animator.Play("Idle");
        }
    }
}

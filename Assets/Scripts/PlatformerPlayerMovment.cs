using System;
using UnityEngine;

public class PlatformerPlayerMovment : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask groundLayer;
    
    [Header("Jump Parameters")]
    private bool _performJump;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider;
    private bool _isFacingRight = true;
    private float _xInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _performJump = true;
        }
        FlipSprite();
    }

    private void FixedUpdate()
    {
        Move();
        
        if (_performJump)
        {
            Jump();
        }
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_xInput * speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _performJump = false;
        _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void FlipSprite()
    {
        if ((_isFacingRight && _xInput < 0f) || (!_isFacingRight && _xInput > 0f))
        {
            _isFacingRight = !_isFacingRight;
            var localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        var raycastHit = Physics2D.BoxCast(
            _boxCollider.bounds.center,
            _boxCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            groundLayer
        );
        return raycastHit.collider != null;
    }
}


using UnityEngine;

namespace Platformer
{
    public class PlatformerPlayerMovment : MonoBehaviour
    {
        [Header("Movement Parameters")]
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 10f;

        [Header("Ground Detection")]
        [SerializeField] private LayerMask groundLayer;
    
        [Header("Jump Parameters")]
        private bool _isJumping;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D _boxCollider;
        private Animator _animator;
        private bool _isFacingRight = true;
        private float _xInput;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.freezeRotation = true;
            _boxCollider = GetComponent<BoxCollider2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _xInput = Input.GetAxisRaw("Horizontal");
        
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                _isJumping = true;
            }
            FlipSprite();
            UpdateAnimation();
        }

        private void FixedUpdate()
        {
            Move();
        
            if (_isJumping)
            {
                Jump();
                _isJumping = false;
            }
        }

        private void Move()
        {
            _rigidbody.velocity = new Vector2(_xInput * speed, _rigidbody.velocity.y);
        }

        private void Jump()
        {
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
    
        private void UpdateAnimation()
        {
            bool isRunning = Mathf.Abs(_xInput) > 0;
            _animator.SetBool("isRunning", isRunning);
            _animator.SetBool("isJumping", !IsGrounded());
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
}


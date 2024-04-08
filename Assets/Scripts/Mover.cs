using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundRadius;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;

    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        Move();

        if (_isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Move()
    {
        float flip = 0.0f;

        Vector2 direction;

        direction.x = Input.GetAxis("Horizontal");

        _animator.SetFloat("moveX", Mathf.Abs(direction.x));

        _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);

        _characterSprite.flipX = direction.x < flip;
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);
        _animator.SetBool("onGround", _isGrounded);
    }
}
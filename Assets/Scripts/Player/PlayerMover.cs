using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundRadius;
    [SerializeField] private InputPlayer _input;
    [SerializeField] private PlayerAnimation _animation;

    private Rigidbody2D _rigidbody;

    private bool _isGrounded;
    private bool _faceRight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        MoveAction();
    }

    private void OnEnable()
    {
        _input.Jumping += JumpAction;
    }

    private void OnDisable()
    {
        _input.Jumping -= JumpAction;
    }

    private void MoveAction()
    {
        float direction = _input.Move;

        _animation.Run(direction);

        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);

        Reflect(direction);
    }

    private void Reflect(float direction)
    {
        float flipX = 0f;
        float flipY = 180f;
        float flipZ = 0f;

        if ((direction > 0 && _faceRight) || (direction < 0 && !_faceRight))
        {
            transform.Rotate(flipX, flipY, flipZ);
            _faceRight = !_faceRight;
        }
    }

    private void JumpAction()
    {
        if (_isGrounded)
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);
        _animation.Jump(_isGrounded);
    }
}
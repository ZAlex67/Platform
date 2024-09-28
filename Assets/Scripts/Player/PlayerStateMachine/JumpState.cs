using UnityEngine;

public class JumpState : State
{
    private float _jumpForce;
    private Transform _groundCheck;
    private LayerMask _groundMask;
    private float _groundRadius;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private PlayerAnimation _animation;
    private InputPlayer _input;
    private Animator _animator;

    public JumpState(StateMachine stateMachine, float jumpForce, Transform groundCheck, LayerMask groundMask, float groundRadius, bool isGrounded, Rigidbody2D rigidbody, Transform transform, Animator animator) : base(stateMachine)
    {
        _jumpForce = jumpForce;
        _groundCheck = groundCheck;
        _groundMask = groundMask;
        _groundRadius = groundRadius;
        _isGrounded = isGrounded;
        _rigidbody = rigidbody;
        _transform = transform;
        _animator = animator;
    }

    public override void Enter()
    {
        _rigidbody.AddForce(_transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
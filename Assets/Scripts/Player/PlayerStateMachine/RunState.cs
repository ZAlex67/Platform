using UnityEngine;

public class RunState : State
{
    private float _moveSpeed;
    private InputPlayer _input;
    private PlayerAnimation _animation;
    private Rigidbody2D _rigidbody;
    private bool _faceRight;
    private Transform _transform;
    private bool _isGrounded;
    private Animator _animator;

    public RunState(StateMachine stateMachine, float moveSpeed, InputPlayer input, PlayerAnimation animation, Rigidbody2D rigidbody, bool faceRight, Transform transform, bool isGrounded, Animator animator) : base(stateMachine)
    {
        _moveSpeed = moveSpeed;
        _input = input;
        _animation = animation;
        _rigidbody = rigidbody;
        _faceRight = faceRight;
        _transform = transform;
        _isGrounded = isGrounded;
        _animator = animator;
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
            _transform.Rotate(flipX, flipY, flipZ);
            _faceRight = !_faceRight;
        }
    }

    public override void Update()
    {
        MoveAction();
    }
}
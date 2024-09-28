using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundRadius;
    [SerializeField] private InputPlayer _input;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private Animator _animator;

    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody;

    private StateMachine _stateMachine;
    private IdleState _idleState;
    private JumpState _jumpState;
    private RunState _runState;

    private bool _isGrounded;
    private bool _faceRight;

    private void OnEnable()
    {
        _input.Jumping += OnJumpAction;
    }

    private void OnDisable()
    {
        _input.Jumping -= OnJumpAction;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _stateMachine = new StateMachine();
        _idleState = new IdleState(_stateMachine, _animation);
        _runState = new RunState(_stateMachine, _moveSpeed, _input, _animation, _rigidbody, _faceRight, transform, _isGrounded, _animator);
        _jumpState = new JumpState(_stateMachine, _jumpForce, _groundCheck, _groundMask, _groundRadius, _isGrounded, _rigidbody, transform, _animator);

        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();

        if (_input.Move == 0 && _isGrounded)
        {
            _stateMachine.ChangeState(_idleState);
        }
        else
        {
            _stateMachine.ChangeState(_runState);
        }
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.FixedUpdate();

        CheckGround();
    }

    private void OnJumpAction()
    {
        if (_isGrounded)
        {
            _stateMachine.ChangeState(_jumpState);

            _audioSource.Play();
        }
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);
        _animation.Jump(_isGrounded);
    }
}
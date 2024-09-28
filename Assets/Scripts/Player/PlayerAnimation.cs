using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    public static readonly int MoveX = Animator.StringToHash(nameof(MoveX));
    public static readonly int OnGrounded = Animator.StringToHash(nameof(OnGrounded));

    private Animator _animator;
    private string _currentState;
    //private string _idle = "Idle";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Idle()
    {
       //_animator.Play(_idle);
    }

    public void Run(float direction)
    {
        _animator.SetFloat(MoveX, Mathf.Abs(direction));
    }

    public void Jump(bool isGrounded)
    {
        _animator.SetBool(OnGrounded, isGrounded);
    }
}
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run(float direction)
    {
        _animator.SetFloat("moveX", Mathf.Abs(direction));
    }

    public void Jump(bool isGrounded)
    {
        _animator.SetBool("onGround", isGrounded);
    }
}
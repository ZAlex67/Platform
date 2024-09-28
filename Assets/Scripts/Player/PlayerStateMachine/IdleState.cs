
public class IdleState : State
{
    private PlayerAnimation _animation;

    public IdleState(StateMachine stateMachine, PlayerAnimation animation) : base(stateMachine)
    {
        _animation = animation;
    }

    public override void Enter()
    {
        _animation.Idle();
    }
}
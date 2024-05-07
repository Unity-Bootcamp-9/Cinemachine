using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerIdleState : JWPlayerGroundState
{
    public JWPlayerIdleState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

    }
}

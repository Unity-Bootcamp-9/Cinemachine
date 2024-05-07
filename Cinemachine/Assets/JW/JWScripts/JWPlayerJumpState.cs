using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerJumpState : JWPlayerState
{
    public JWPlayerJumpState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
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

        controller.animator.SetFloat("yVelocity", controller.rb.velocity.y);

        if(controller.isGrounded)
        {
            stateMachine.SetState(controller.idleState);
        }
    }
}

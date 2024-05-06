using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerWalkingState : JWPlayerGroundState
{
    public JWPlayerWalkingState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
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

        if(controller.horizontal == 0 & controller.vertical == 0)
        {
            stateMachine.SetState(controller.idleState);
        }
    }
}

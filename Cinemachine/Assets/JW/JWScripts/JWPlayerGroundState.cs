using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerGroundState : JWPlayerState
{
    public JWPlayerGroundState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
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

        if(Input.GetKeyDown(KeyCode.F))
        {
            stateMachine.SetState(controller.readyState);
        }

        if ((controller.horizontal != 0 || controller.vertical != 0) && Input.GetKey(KeyCode.LeftShift))
        {
            stateMachine.SetState(controller.runningState);
        }

        else if (controller.horizontal != 0 || controller.vertical != 0)
        {
            stateMachine.SetState(controller.walkingState);
        }
       
    }
}

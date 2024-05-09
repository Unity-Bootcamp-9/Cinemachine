using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerRunJumpState : JWPlayerState
{
    public JWPlayerRunJumpState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
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

        controller.transform.Translate(Vector3.forward * 10 * Time.deltaTime);

        if(controller.animTrigger.endTrigger)
        {
            stateMachine.SetState(controller.idleState);
        }
    }
}

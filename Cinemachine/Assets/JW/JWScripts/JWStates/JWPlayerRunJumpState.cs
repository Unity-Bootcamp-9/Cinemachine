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

        player.transform.Translate(Vector3.forward * 10 * Time.deltaTime);

        if(player.animTrigger.endTrigger)
        {
            stateMachine.SetState(player.idleState);
        }
    }
}

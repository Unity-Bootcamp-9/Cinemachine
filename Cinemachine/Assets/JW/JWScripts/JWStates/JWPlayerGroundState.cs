using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerGroundState : JWPlayerState
{
    public float moveSpeed;
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            stateMachine.SetState(player.readyState);
        }
        
        if(Input.GetKey(KeyCode.Q)) 
        {
            stateMachine.SetState(player.jumpAttackState);
        }

        if(Input.GetKey(KeyCode.R))
        {
            stateMachine.SetState(player.lockonState);
        }

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            stateMachine.SetState(player.runningState);
        }

        else if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            stateMachine.SetState(player.walkingState);
        }
    }
}

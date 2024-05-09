using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerReadyState : JWPlayerGroundState
{
    public JWPlayerReadyState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        camController.SetCamera(camController.zoomCam);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKeyUp(KeyCode.F)) 
        {
            stateMachine.SetState(player.idleState);
        }
    }
}

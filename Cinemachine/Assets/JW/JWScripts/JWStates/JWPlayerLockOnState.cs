using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerLockonState : JWPlayerState
{
    public JWPlayerLockonState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        camController.SetCamera(camController.lockOnCam);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Vector3 direction = player.target.transform.position - player.transform.position;
        direction.y = 0;

        player.transform.rotation = Quaternion.LookRotation(direction);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(-v, 0f, -h).normalized;

        player.rb.velocity = movement * 5;

        if (h != 0 || v!= 0)
        {
            player.animator.SetBool("Ready", false);
            player.animator.SetBool("Walk", true);
        }
        else
        {
            player.animator.SetBool("Ready", true);
            player.animator.SetBool("Walk", false);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            stateMachine.SetState(player.idleState);
        }
    }
}

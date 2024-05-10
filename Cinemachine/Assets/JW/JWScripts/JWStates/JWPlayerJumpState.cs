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

    public float jumpForce = 1f;
    public override void Update()
    {
        base.Update();

        player.animator.SetFloat("yVelocity", player.rb.velocity.y);

        if (player.animTrigger.isJumping & player.rb.velocity.y < 5)
        {
            player.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Active");
        }

        if(!player.isGrounded)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            player.transform.Translate(h * Time.deltaTime * 2, 0, v * Time.deltaTime * 2);
        }

        if (player.animTrigger.endTrigger)
        {
            stateMachine.SetState(player.idleState);
        }
    }
}

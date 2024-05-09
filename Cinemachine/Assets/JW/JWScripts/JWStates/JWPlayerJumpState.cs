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

        controller.animator.SetFloat("yVelocity", controller.rb.velocity.y);

        if (controller.animTrigger.isJumping & controller.rb.velocity.y < 5)
        {
            controller.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Active");
        }

        if(!controller.isGrounded)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            controller.transform.Translate(h * Time.deltaTime * 2, 0, v * Time.deltaTime * 2);
        }

        if (controller.animTrigger.endTrigger)
        {
            stateMachine.SetState(controller.idleState);
        }
    }
}

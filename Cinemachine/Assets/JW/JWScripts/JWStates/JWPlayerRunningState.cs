using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerRunningState : JWPlayerGroundState
{
    public JWPlayerRunningState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(controller, stateMachine, animator, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        moveSpeed = 50f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Vector3.Scale(player.mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = vertical * cameraForward + horizontal * player.mainCamera.transform.right;

        player.rb.MovePosition(player.transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, player.rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(player.runJumpState);
        }

        if (horizontal == 0 & vertical == 0)
        {
            stateMachine.SetState(player.idleState);
        }
    }
}

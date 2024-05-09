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
        moveSpeed = 20;
        base.Enter();
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

        // ���콺 ��ġ�� �ޱ�
        Vector3 mousePosition = Input.mousePosition;
        // ī�޶�� ���콺 ��ġ�� ������ ���� ���ϱ�
        float angle = Vector3.SignedAngle(player.mainCamera.transform.forward, mousePosition - player.mainCamera.WorldToScreenPoint(player.transform.position), Vector3.up);

        // �¿� ����
        if (angle < 0)
        {
            horizontal = -horizontal;
        }

        player.rb.MovePosition(player.transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, player.rotateSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            stateMachine.SetState(player.runningState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(player.runJumpState);
        }

        if (horizontal == 0 && vertical == 0)
        {
            stateMachine.SetState(player.idleState);
        }
    }
}

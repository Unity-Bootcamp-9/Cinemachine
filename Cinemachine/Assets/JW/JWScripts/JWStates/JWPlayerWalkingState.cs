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

        Vector3 cameraForward = Vector3.Scale(controller.mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = vertical * cameraForward + horizontal * controller.mainCamera.transform.right;

        // 마우스 위치값 받기
        Vector3 mousePosition = Input.mousePosition;
        // 카메라와 마우스 위치값 사이의 각도 구하기
        float angle = Vector3.SignedAngle(controller.mainCamera.transform.forward, mousePosition - controller.mainCamera.WorldToScreenPoint(controller.transform.position), Vector3.up);

        // 좌우 반전
        if (angle < 0)
        {
            horizontal = -horizontal;
        }

        controller.rb.MovePosition(controller.transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, targetRotation, controller.rotateSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            stateMachine.SetState(controller.runningState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(controller.runJumpState);
        }

        if (horizontal == 0 & vertical == 0)
        {
            stateMachine.SetState(controller.idleState);
        }
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class JWPlayerController : MonoBehaviour
{
    public Animator animator;
    public Camera mainCamera;
    public AnimationTrigger animTrigger;

    #region States
    public JWPlayerStateMachine stateMachine;
    public JWPlayerIdleState idleState;
    public JWPlayerWalkingState walkingState;
    public JWPlayerRunningState runningState;
    public JWPlayerJumpState jumpState;
    public JWPlayerReadyState readyState;
    public JWPlayerRunJumpState runJumpState;
    public JWPlayerJumpAttackState jumpAttackState;
    #endregion

    Vector3 mouseDir;
    public float moveSpeed;
    public float runSpeed;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public bool isGrounded;
    public float layLength;

    public Rigidbody rb;

    public CinemachineVirtualCameraBase defaultCamera;
    public CinemachineVirtualCameraBase zoomInCamera;
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        animTrigger = GetComponentInChildren<AnimationTrigger>();

        stateMachine = new JWPlayerStateMachine();

        idleState = new JWPlayerIdleState(this, stateMachine, animator, "Idle");
        walkingState = new JWPlayerWalkingState(this, stateMachine, animator, "Walk");
        runningState = new JWPlayerRunningState(this, stateMachine, animator, "Run");
        jumpState = new JWPlayerJumpState(this, stateMachine, animator, "Jump");
        readyState = new JWPlayerReadyState(this, stateMachine, animator, "Ready");
        runJumpState = new JWPlayerRunJumpState(this, stateMachine, animator, "RunJump");
        jumpAttackState = new JWPlayerJumpAttackState(this, stateMachine, animator, "JumpAttack");
    }

    private void Start()
    {
        stateMachine.Init(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
        //Move();
        Jump();
        GroundCheck();
        CameraChange();
        Debug.Log(stateMachine.currentState);
    }


    public float horizontal;
    public float vertical;

    //private void Move()
    //{
    //    horizontal = Input.GetAxisRaw("Horizontal");
    //    vertical = Input.GetAxisRaw("Vertical");

    //    Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
    //    Vector3 moveDirection = vertical * cameraForward + horizontal * mainCamera.transform.right;

    //    if(isGrounded)
    //    {
    //        if(stateMachine.GetState() == runningState)
    //        {
    //            rb.MovePosition(transform.position + moveDirection.normalized * runSpeed * Time.deltaTime);
    //        }
    //        else
    //        {
    //             rb.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
    //        }

    //        if (moveDirection != Vector3.zero)
    //        {
    //            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
    //            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    //        }
    //    }
    //}

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = vertical * cameraForward + horizontal * mainCamera.transform.right;

        // ���콺 ��ġ�� �ޱ�
        Vector3 mousePosition = Input.mousePosition;
        // ī�޶�� ���콺 ��ġ�� ������ ���� ���ϱ�
        float angle = Vector3.SignedAngle(mainCamera.transform.forward, mousePosition - mainCamera.WorldToScreenPoint(transform.position), Vector3.up);

        // �¿� ����
        if (angle < 0)
        {
            horizontal = -horizontal;
        }

        if (isGrounded)
        {
            if (stateMachine.GetState() == runningState)
            {
                rb.MovePosition(transform.position + moveDirection.normalized * runSpeed * Time.deltaTime);
            }
            else
            {
                rb.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
            }

            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
        }
    }


    private void GroundCheck()
    {
        Debug.DrawRay(groundCheck.position, Vector3.down * layLength, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, layLength))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public float rotateSpeed;

    private void Jump()
    {
        animator.SetBool("isGrounded", isGrounded);
        //if (Input.GetKey(KeyCode.Space) && isGrounded)
        //{
        //    rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //}
    }
    
    private void CameraChange()
    {
        if(stateMachine.GetState() == readyState)
        {
            zoomInCamera.enabled = true;
            defaultCamera.enabled = false;
        }
        else
        {
            zoomInCamera.enabled = false;
            defaultCamera.enabled = true;
        }
    }
}

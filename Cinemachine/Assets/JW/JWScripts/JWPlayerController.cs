using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using static UnityEngine.UI.Image;

public class JWPlayerController : MonoBehaviour
{
    public JWPlayerStateMachine stateMachine;
    public Animator animator;
    public Camera mainCamera;

    public JWPlayerIdleState idleState;
    public JWPlayerWalkingState walkingState;
    public JWPlayerRunningState runningState;
    public JWPlayerJumpState jumpState;
    public JWPlayerReadyState readyState;

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

        stateMachine = new JWPlayerStateMachine();

        idleState = new JWPlayerIdleState(this, stateMachine, animator, "Idle");
        walkingState = new JWPlayerWalkingState(this, stateMachine, animator, "Walk");
        runningState = new JWPlayerRunningState(this, stateMachine, animator, "Run");
        jumpState = new JWPlayerJumpState(this, stateMachine, animator, "Jump");
        readyState = new JWPlayerReadyState(this, stateMachine, animator, "Ready");
    }

    private void Start()
    {
        stateMachine.Init(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
        Move();
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

        // 마우스 위치값 받기
        Vector3 mousePosition = Input.mousePosition;
        // 카메라와 마우스 위치값 사이의 각도 구하기
        float angle = Vector3.SignedAngle(mainCamera.transform.forward, mousePosition - mainCamera.WorldToScreenPoint(transform.position), Vector3.up);

        // 좌우 반전
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

    public float jumpForce;
    public float rotateSpeed;

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
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

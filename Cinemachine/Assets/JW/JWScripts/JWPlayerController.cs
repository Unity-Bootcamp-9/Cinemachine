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
    public JWCameraController camController;

    #region States
    public JWPlayerStateMachine stateMachine;
    public JWPlayerIdleState idleState;
    public JWPlayerWalkingState walkingState;
    public JWPlayerRunningState runningState;
    public JWPlayerJumpState jumpState;
    public JWPlayerReadyState readyState;
    public JWPlayerRunJumpState runJumpState;
    public JWPlayerJumpAttackState jumpAttackState;
    public JWPlayerBossEntryState bossEntryState;
    public JWPlayerLockonState lockonState;
    #endregion
    public GameObject target;

    public bool bossTrigger = false;

    public float rotateSpeed;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public bool isGrounded;
    public float layLength;

    public Rigidbody rb;

    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        animTrigger = GetComponentInChildren<AnimationTrigger>();
        camController = GetComponent<JWCameraController>();

        stateMachine = new JWPlayerStateMachine();

        idleState = new JWPlayerIdleState(this, stateMachine, animator, "Idle");
        walkingState = new JWPlayerWalkingState(this, stateMachine, animator, "Walk");
        runningState = new JWPlayerRunningState(this, stateMachine, animator, "Run");
        jumpState = new JWPlayerJumpState(this, stateMachine, animator, "Jump");
        readyState = new JWPlayerReadyState(this, stateMachine, animator, "Ready");
        runJumpState = new JWPlayerRunJumpState(this, stateMachine, animator, "RunJump");
        jumpAttackState = new JWPlayerJumpAttackState(this, stateMachine, animator, "JumpAttack");
        lockonState = new JWPlayerLockonState(this, stateMachine, animator, "Ready");
        bossEntryState = new JWPlayerBossEntryState(this, stateMachine, animator, "Idle");
    }

    private void Start()
    {
        stateMachine.Init(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
        animator.SetBool("isGrounded", isGrounded);

        GroundCheck();
        Debug.Log(stateMachine.currentState);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BossTrigger"))
        {
            bossTrigger = true;
        }
    }
}

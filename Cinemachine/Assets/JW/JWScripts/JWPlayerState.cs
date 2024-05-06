using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JWPlayerState
{
    public JWPlayerController controller;
    public JWPlayerStateMachine stateMachine;
    public string animBool;
    Animator animator;


    public JWPlayerState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool)
    {
        this.controller = controller;
        this.stateMachine = stateMachine;
        this.animator = animator;
        this.animBool = animBool;
    }

    public virtual void Enter()
    {
        animator.SetBool(animBool, true);
    }

    public virtual void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            stateMachine.SetState(controller.jumpState);
        }
    }

    public virtual void Exit()
    {
        animator.SetBool(animBool, false);
    }
}

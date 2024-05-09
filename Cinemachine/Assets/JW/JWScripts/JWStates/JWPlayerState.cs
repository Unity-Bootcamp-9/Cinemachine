using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JWPlayerState
{
    public JWPlayerController player;
    public JWPlayerStateMachine stateMachine;
    public JWCameraController camController;
    public string animBool;
    Animator animator;


    public JWPlayerState(JWPlayerController controller, JWPlayerStateMachine stateMachine, Animator animator, string animBool)
    {
        player = controller;
        this.stateMachine = stateMachine;
        this.animator = animator;
        this.animBool = animBool;
        camController = player.camController;
    }

    public virtual void Enter()
    {
        animator.SetBool(animBool, true);
    }

    public virtual void Update()
    {
        if(player.bossTrigger)
        {
            stateMachine.SetState(player.bossEntryState);
        }
    }

    public virtual void Exit()
    {
        animator.SetBool(animBool, false);

        player.animTrigger.TriggerReset();

        camController.SetCamera(camController.baseCam);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerBossEntryState : JWPlayerState
{
    public JWPlayerBossEntryState(JWPlayerController player, JWPlayerStateMachine stateMachine, Animator animator, string animBool) : base(player, stateMachine, animator, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        camController.SetCamera(camController.bossCamera);
    }

    public override void Exit()
    {
        base.Exit();
    }

    float timer = 5f;
    public override void Update()
    {
        base.Update();

        timer -= Time.deltaTime;

        Debug.Log(timer);

        if (timer < 0)
        {
            stateMachine.SetState(player.idleState);
            player.bossTrigger = false;
        }

    }
}

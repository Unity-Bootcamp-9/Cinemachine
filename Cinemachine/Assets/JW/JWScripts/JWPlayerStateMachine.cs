using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWPlayerStateMachine 
{
    public JWPlayerState currentState;

    public void Init(JWPlayerState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void SetState(JWPlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public JWPlayerState GetState()
    {
        return currentState;
    }
}

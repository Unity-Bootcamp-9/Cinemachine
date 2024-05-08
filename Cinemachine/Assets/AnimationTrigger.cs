using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public bool endTrigger;
    public bool isJumping;
    public bool canMove;

    public bool AnimTrigger() { return endTrigger; }
    public bool IsJumping() { return isJumping; }
    public bool CanMove() { return canMove; }

    public void TriggerReset() 
    { 
        endTrigger = false;
        canMove = true;
    }
    public void StartJump() { isJumping = true; }
    public void EndJump() { isJumping = false; }
    public void StopMove() { canMove = false; }
    public void EndTriggerSet() { endTrigger = true; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNinjaController : MonoBehaviour
{

    public Animator AnimatorRef;

    public AnimationState currentState;

    // Start is called before the first frame update
    void Start()
    {
        AnimatorRef = GetComponent<Animator>();
        currentState = new AnimationState() { MovementState = State.IDLE, ActionState = State.IDLE  } ;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();        
    }


    public void ChangeState(AnimationState state)
    {
        if(currentState.Compare(state))
        {
            currentState = state;
        }
    }


    public void UpdateState()
    {
        
    }

    public void UpdateAnimations()
    {
        ValidadeState(currentState);
    }
    public void  ValidadeState(AnimationState newState) {
        bool isWalking = currentState.MovementState == State.WALK;
        bool isShooting = currentState.ActionState == State.SHOOTING;
        AnimatorRef.SetBool("IsWalkingBool", isWalking);
        AnimatorRef.SetBool("isShooting", isShooting);
        AnimatorRef.SetFloat("Velocity", newState.WalkVelocity);
    }

    public void SetLayerWeight( float weight)
    {
        AnimatorRef.SetLayerWeight(1, weight);
    }

}



public enum State
{
    WALK,
    RUN,
    INJURED,
    IDLE,
    SHOOTING,
    JUMP
}


public struct AnimationState
{
    public State MovementState;
    public State ActionState;
    public float WalkVelocity;

    public bool Compare(AnimationState stateToCompare)
    {
        if(this.MovementState != stateToCompare.MovementState)
        {
            return true;
        }
        if (this.ActionState != stateToCompare.ActionState)
        {
            return true;
        }
        if (this.WalkVelocity != stateToCompare.WalkVelocity)
        {
            return true;
        }
        return false;
    }
}


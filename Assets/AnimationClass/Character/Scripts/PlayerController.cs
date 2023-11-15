using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public AnimationNinjaController AnimationNinjaControllerRef;
    void Start()
    {
        AnimationNinjaControllerRef = GetComponent<AnimationNinjaController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimationNinjaControllerRef.ChangeState(new AnimationState() { ActionState = State.SHOOTING, MovementState = State.WALK, WalkVelocity = 0 });
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            AnimationNinjaControllerRef.ChangeState(new AnimationState() { ActionState = State.SHOOTING, MovementState = State.WALK, WalkVelocity = 1});
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            AnimationNinjaControllerRef.SetLayerWeight(0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AnimationNinjaControllerRef.SetLayerWeight(1);
        }

    }
}

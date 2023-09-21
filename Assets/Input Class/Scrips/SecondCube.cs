using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SecondCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void JumpSecondCube(CallbackContext contextEvent)
    {
        if(contextEvent.phase == InputActionPhase.Performed)
        {
            Debug.Log("JUMP CUBE 2");
        }
    }
}

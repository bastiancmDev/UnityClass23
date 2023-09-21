using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PjInputController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public InputMap InputManager;


    public List<string> ComboBase;
    public List<List<string>> AllCombos;
    public Queue<InputRegistry> ActualInputRegistry;
    

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
       
    }


    void Start()
    {
        InputManager = new InputMap();
        InputManager.Enable();
        AllCombos = new List<List<string>>();
        rb = GetComponent<Rigidbody>();       
        ComboBase = new List<string>() {"JUMP","JUMP","JUMP"};
        AllCombos.Add(ComboBase);
        ActualInputRegistry = new Queue<InputRegistry>();


        InputManager.PlayerMove.Jump.performed += Jump;

    }

    
    // Update is called once per frame
    void Update()
    {
        float horizotal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3 (horizotal, 0, vertical);
        
    }


    public void Jump(CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            Debug.Log("JUMP");

            SaveInputEvent("JUMP");
            ValidateAllCombos();
        }
       
    }

    public void OnTurn (CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //InputManager.defaultActionMap = "OnPlayerFly";
        }

    }



    public void SaveInputEvent(string id)
    {
        ActualInputRegistry.Enqueue(new InputRegistry { Id = id, Time = DateTime.Now });
    }


    public bool ComboValidator(List<string> currentComboToValidate)
    {
        if(ActualInputRegistry.Count < currentComboToValidate.Count) {
            return false;
        }
        else
        {
            var subListCombo = ActualInputRegistry;//.GetRange(ActualInputRegistry.Count - currentComboToValidate.Count, currentComboToValidate.Count);
            for(int i = 0; i < subListCombo.Count; i++)
            {
                if (subListCombo.Dequeue().Id != currentComboToValidate[i])
                {
                    return false;
                }
            }
            Debug.Log("COMBO VALIDATOR RETURN TRUE FOR  COMBO [currentComboToValidate]");
            return true;
        }
    }


    public void ValidateAllCombos()
    {
        foreach (var combo in AllCombos) {
            ComboValidator(combo);
        }
    }


    
}

public struct InputRegistry
{
    public string Id;
    public DateTime Time;
}

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
    // InputActionMap _playerMoveAction; // Opcional, crear un action map del que se usara para tener un mejor control de cuales se estan usando.

    public List<string> ComboBase;
    public List<List<string>> AllCombos;
    public Queue<InputRegistry> ActualInputRegistry;
    private bool isJumping;

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }


    void Start()
    {
        InputManager = new InputMap(); // Creamos el input map. Muy importante ya que no es una clase global, tendremos que crearla en nuestro script!!
        InputManager.Enable(); // Activamos el inputManager. Aunque es preferible activar el Action Map solo, si tenemos en playerfly ya configurado estaria funcionando a la par que el playermove.
        // _playerMoveAction = InputManager.PlayerMove; // Asignamos el action map
        // _playerMoveAction.Enable(); // iniciamos solo el action map que usaremos
        AllCombos = new List<List<string>>(); // Creamos una lista de lista de combos.... En resumen una lista que cada casilla tiene una serie de combos osea otra lista xd
        rb = GetComponent<Rigidbody>(); // Le asignamos el RigidBody de nuestro GameObject. ¡¡Atencion, si no tiene un RB va a tirar un problema!!
        ComboBase = new List<string>() { "JUMP", "JUMP", "JUMP" }; // Pre seteamos un combo basico
        AllCombos.Add(ComboBase); // Agregamos el combo a la lista de combos
        ActualInputRegistry = new Queue<InputRegistry>(); // Creamos un registro de las teclas precionadas


        InputManager.PlayerMove.Jump.started += StartJump; // Nos suscribimos al evento de performed de jump a la funcion Jump.
        InputManager.PlayerMove.Jump.canceled += EndJump; // Nos suscribimos al evento de performed de jump a la funcion Jump.
        InputManager.PlayerMove.Walk.performed += Walk; // lo mismo pero con walk

    }

    private void EndJump(CallbackContext obj)
    {
        isJumping = false;
    }

    private void StartJump(CallbackContext obj)
    {
        isJumping = true;
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            //player.addForce(vector3.up * 10);
        }
    }

    private void Walk(CallbackContext context)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float horizotal = Input.GetAxis("Horizontal"); // Nos traemos los valores del input Derecha e Izquierda entre 0 y 1
        float vertical = Input.GetAxis("Vertical"); // Lo mismo pero Delante y Detras
        
        transform.position = transform.position + new Vector3 (horizotal, 0, vertical); // Cambiamos la pocicion usando las variables que adquirimos
        
    }


    public void Jump(CallbackContext context) // Se ejecuta al dispararse el evento de Jump de nuestro ActionMap
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



    public void SaveInputEvent(string id) // Guardamos el input en nuestro struct para luego agregarlo a la lista de los inputs acutales del combo
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

public struct InputRegistry // Struct para guardar los Registros del input
{
    public string Id;
    public DateTime Time;
}

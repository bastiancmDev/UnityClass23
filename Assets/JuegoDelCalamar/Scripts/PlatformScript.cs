using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int _id;

    [SerializeField]
    private bool _isFake;

    private CalamarGameController _controller;

    private void Awake() // Seteamos en Fake, quiere decir que todas las plataformas seran Fake al principio
    {
        SetIsFake(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor()
    {
        if(_isFake) // Si es fake seteamos el color a rojo
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }        
    }

    public int GetId() // Rerornamos la ID de nuestra plataforma
    {
        return _id;
    }

    public void SetId(int id) // Seteamos la ID
    {
        this._id = id;
    }

    public bool GetIsFake() // Retornamos el valor de la variable _isFake
    {
        return _isFake;
    }

    public void SetIsFake(bool isFake) // Seteamos la variable
    {
        _isFake = isFake;
    }

    public Vector3 GetPosition() // Devolvemos la posicion de nuestra plataforma
    {
        return transform.position;
    }

    private void OnMouseDown() // Evento que se llama al clickear sobre un GameObjecto que contenga este Script
    {
        Debug.Log("ACABAS DE CLICKEAR UN ELEMENTO CON POSITION " + GetPosition());
        if(_controller == null) // en caso de que el controller sea nulo le asignamos uno si se encuentra en el escenario
        {
            _controller = GameObject.FindObjectOfType<CalamarGameController>();
        }
        // en caso de no haber un controller al tratar de seguir la proxima linea nos crasheara porque no hay nada que evite que se use el llamado si no hay un controller
        _controller.OnPlataformClicked(GetId());
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> _pool;

    [SerializeField] GameObject _ballPrefab;

    [SerializeField] int _initialCountOfPool;
    private bool _creatingObject = false;

    void Start()
    {
        _pool = new List<GameObject>();

        for(int i = 0; i< _initialCountOfPool; i++) // Fijamos una cantidad de objetos creados al iniciar la pool
        {
            var ballToShot = Instantiate(_ballPrefab);
            ballToShot.SetActive(false);
            _pool.Add(ballToShot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) { // <--- Me da crinch la llave ahi >.< (No es malo pero te puede llega a generar confuciones jaja)
            if (!_creatingObject) // Ejecutamos solo cuando no estamos creando un objeto
            {
                _creatingObject = true;
                GameObject ballToShot = GetBallFromPool();
                ballToShot.SetActive(true);
                ballToShot.GetComponent<Rigidbody>().AddForce(ballToShot.transform.right * 12, ForceMode.VelocityChange); // Esto no se hace en el update >.< no olviden trabajar las fisicas en el Fixed
                // segundo tip: en este caso no pasa nada porque se llama una vez, pero en otros combiene asignar el rigidbodi a una variable para no estar llamando al getcomponent a cada rato(mas costoso).
                _creatingObject = false;
            }           
        }        
    }


    public GameObject GetBallFromPool() { // obtenemos una ball desactivada para disparar, y si no tenemos, creamos una.
        
        GameObject ballToShot;
        if ( _pool.Count > 0 ) { 
            ballToShot =  _pool[0];
            _pool.RemoveAt(0);
        }
        else
        {
            ballToShot = Instantiate(_ballPrefab);                        
        }
        ballToShot.transform.position = new Vector3(-3, 0, 0);
        ballToShot.GetComponent<ShotBall>().NotifyCollision = OnBallCollosion; // asignamos la funcion al action. (Primera vez que lo veo)
        return ballToShot;
    }


    public void OnBallCollosion(GameObject ballToAddToPoll) // Se llama cuando la bola activa el evento
    {              
        _pool.Add(ballToAddToPoll);
    }
}

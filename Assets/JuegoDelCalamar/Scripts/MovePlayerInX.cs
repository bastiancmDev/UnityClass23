using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerInX : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    // Start is called before the first frame update
    void Start()
    {
        // iniciamos la Coorrutina
        StartCoroutine(MovePlayerInXCorrountine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePlayerInXCorrountine()
    {
        float initialPositionInX = transform.position.x;
        for(int i = 0; i < 10000; i++) { // el abrir corchetes preferible hacerlo abajo en una linea diferente se pueden evitar confusiones.
            float t = (float)i / 10000f;
            // Movemos al player usando Lerp( el primer valor es el valor actual,
            // el segundo es el valor que queres que tenga el primer valor y el tercero es la velocidad la cual el primer valor va a llegar al segundo )
            float newX = Mathf.Lerp(initialPositionInX, initialPositionInX + 300, t);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z); // Asignamos el valor de lerp a nuestro vector en X para moverlo
            yield return new WaitForSeconds(0.01f); // espereamos 0.01 segundos
        }        
    }
}

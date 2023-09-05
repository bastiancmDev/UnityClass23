using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atomo : MonoBehaviour
{
    public Transform center; // El objeto central alrededor del cual giran los electrones.
    public float orbitSpeed = 50f; // Velocidad de órbita.
    public float orbitRadius = 2f; // Radio de la órbita.

    private void Update()
    {
        // Rotar el objeto central (núcleo) si se desea.
        center.Rotate(Vector3.up * orbitSpeed);

        
    }

    
}

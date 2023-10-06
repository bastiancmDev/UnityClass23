using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    // Start is called before the first frame update
    // Update Git Camera Controller

    [SerializeField]
    List<GameObject> _cameras;

    void Start()
    {
        // Inicializamos la lista de GameObjects
        _cameras = new List<GameObject>();

        // Inicializamos la variable con la cantidad de Hijos del Objeto que lleva el script
        var ChildsCount = transform.childCount;

        // Iteramos una vez por hijo, y le asignamos a la lista el GameObject del hijo en el que estamos
        for (int i = 0; i < ChildsCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            child.SetActive(false);
            _cameras.Add(child);
        }
        // Seleccionamos al camara que vamos a usar
        SelectCamera(0);

    }

    // Update is called once per frame
    void Update()
    {
        // Comprobamos si en el frame se preciono la Tecla. En este caso el espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Comprobamos en que camara estamos y si el numero de camra en el que estamos no supera la cantidad pasamos a la siguiente
            int NumberOfCurrentCamera = GetNumberOfCurrentCamera();
            if (NumberOfCurrentCamera + 1 < _cameras.Count)
            {
                Debug.Log("Numero De Camara a activar" + NumberOfCurrentCamera);
                SelectCamera(NumberOfCurrentCamera + 1);
            }
            // Si no se cumple volvemos a la 0 para repetir el proceso
            else
            {
                Debug.Log("Numero De Camara a activar" + NumberOfCurrentCamera);
                SelectCamera(0);
            }
        }
    }

    public void SelectCamera(int CameraNumber)
    {
        // Primero verificamos si el numero que se recivio no es mayor al numero de camaras
        if (CameraNumber < _cameras.Count)
        {
            // Iteramos por cada camara para desactivar todas excepto la que se ingreso
            for (int i = 0; i < _cameras.Count; i++)
            {
                if (i == CameraNumber)
                {
                    _cameras[i].SetActive(true);
                }
                else
                {
                    _cameras[i].SetActive(false);
                }
            }
        }
        // En caso de que el numero sea mayor al numero de camaras Creamos un Log de error describiendo el problema
        else
        {
            Debug.LogError("Cameras count is lees than CameraNumber");
            return;
        }

    }


    public int GetNumberOfCurrentCamera()
    {
        // Iteramos por cada camara y en cuanto se encuentre la que esta activa, devolvemos el numero de camara.
        for (int i = 0; i < _cameras.Count; i++)
        {
            if (_cameras[i].activeSelf)
            {
                return i;
            }
        }
        // si no se encontro se manda un Log que no se tiene una camara activa
        Debug.LogError("No have camera active");
        return -1;
    }
}

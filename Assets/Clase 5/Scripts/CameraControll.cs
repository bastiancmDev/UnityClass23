using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    // Start is called before the first frame update
    // Update Git Camera Controller

    [SerializeField]
    List<GameObject> _cameras;

    void Start()
    {
        Debug.log('hola soy benjamin');
        _cameras = new List<GameObject>();
        _cameras = new List<GameObject>();
        _cameras = new List<GameObject>();
        //lkasdlk
        var ChildsCount = transform.childCount;

        for (int i = 0; i < ChildsCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            child.SetActive(false);
            _cameras.Add(child);
        }
        SelectCamera(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int NumberOfCurrentCamera = GetNumberOfCurrentCamera();
            if (NumberOfCurrentCamera + 1 < _cameras.Count)
            {
                Debug.Log("Numero De Camara a activar" + NumberOfCurrentCamera);
                SelectCamera(NumberOfCurrentCamera + 1);
            }
            else
            {
                Debug.Log("Numero De Camara a activar" + NumberOfCurrentCamera);
                SelectCamera(0);
            }
        }
    }

    public void SelectCamera(int CameraNumber)
    {
        if (CameraNumber < _cameras.Count)
        {
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
        else
        {
            Debug.LogError("Cameras count is lees than CameraNumber");
            return;
        }

    }


    public int GetNumberOfCurrentCamera()
    {
        for (int i = 0; i < _cameras.Count; i++)
        {
            if (_cameras[i].activeSelf)
            {
                return i;
            }
        }
        Debug.LogError("No have camera active");
        return -1;
    }
}

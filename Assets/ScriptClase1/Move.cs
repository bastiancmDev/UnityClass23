using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private GameObject _targetCube;
    
        
    // Start is called before the first frame update

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_targetCube.transform.position);
    }
}

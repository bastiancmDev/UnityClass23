using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSolarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<Transform> _planets;
    private List<Vector3> _rotations;
    [SerializeField]
    private float _speed;

    void Start()
    {
        _planets = new List<Transform>();
        _rotations = new List<Vector3>();
        int childsCounts = transform.childCount;
        for (int i = 0; i < childsCounts; i++)
        {
            if(transform.GetChild(i).tag == "Planet")
            {
                 _planets.Add(transform.GetChild(i));
                _rotations.Add(new Vector3(UnityEngine.Random.Range(0, 2),UnityEngine.Random.Range(0, 2),UnityEngine.Random.Range(0, 2)));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       for(int i = 0; i < _planets.Count ; i++)
       {
            float distance = Vector3.Distance(_planets[i].position, transform.position);
            if(distance != 0)
            {
                _planets[i].RotateAround(transform.position, _rotations[i], _speed / distance);
            }
       }

       
    }
}

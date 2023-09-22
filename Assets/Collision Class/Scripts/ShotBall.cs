using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShotBall : MonoBehaviour
{
    // Start is called before the first frame update

    public Action<GameObject> NotifyCollision;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name.Equals("Cube (1)"))
        {
            NotifyCollision.Invoke(gameObject);
            gameObject.SetActive(false);
        }
        

    }



}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functesting : MonoBehaviour
{
    // Start is called before the first frame update
    public Func<int,int,bool> MiEvento;

    void Start()
    {
        MiEvento = Init;
    }

    // Update is called once per frame
    void Update()
    {
        MiEvento.Invoke(1,2);
    }

    public bool Init(int a, int b)
    {
        return false;
    }
}

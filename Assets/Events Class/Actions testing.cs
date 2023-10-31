using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionstesting : MonoBehaviour
{
    // Los actions no pueden devolver ningun valor de retorno
    public Action<bool> MiEvento;

    void Start()
    {
        MiEvento = Init;
    }

    // Update is called once per frame
    void Update()
    {
       // MiEvento?.Invoke(false);
    }


    public void Init(bool value)
    {
        Debug.Log(value);
    }


}

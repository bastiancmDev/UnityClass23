using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegatetesting : MonoBehaviour
{
    // Start is called before the first frame update


    // definimos de que tipo (valores de entrada y salida) tendra el evento (delegate)
    public delegate int MiDelegado(bool a,int b);

    // creamos una variable de tipo Midelegado donde se va a guarda la referencia a la metodo
    public  static event MiDelegado MiEvento;

    void Start()
    {
        MiEvento = Init;
    }

    // Update is called once per frame
    void Update()
    {
        int valorDeRetorno = MiEvento.Invoke(true, 0);
    }


    public int Init(bool a, int b)
    {
        return b;
    }

    public void DestroyObject()
    {
        
    }
}

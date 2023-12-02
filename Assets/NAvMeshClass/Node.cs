using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var padre = new NodeModel();
        padre.Valor = 1;
        var nodo2 = new NodeModel();
        nodo2.Valor = 2;
        var nodo3 = new NodeModel();
        nodo3.Valor = 3;
        padre.hijos = new List<NodeModel>() { nodo2,nodo3 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class NodeModel
{
    public int Valor;
    public List<NodeModel> hijos;
}



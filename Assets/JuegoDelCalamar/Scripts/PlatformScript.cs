using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int _id;

    [SerializeField]
    private bool _isFake;

    private CalamarGameController _controller;

    private void Awake()
    {
        SetIsFake(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor()
    {
        if(_isFake)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }        
    }

    public int GetId()
    {
        return _id;
    }

    public void SetId(int id)
    {
        this._id = id;
    }

    public bool GetIsFake()
    {
        return _isFake;
    }

    public void SetIsFake(bool isFake)
    {
        _isFake = isFake;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log("ACABAS DE CLICKEAR UN ELEMENTO CON POSITION " + GetPosition());
        if(_controller == null)
        {
            _controller = GameObject.FindObjectOfType<CalamarGameController>();
        }
        _controller.OnPlataformClicked(GetId());

       
    }

}

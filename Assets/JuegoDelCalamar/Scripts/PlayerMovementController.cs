using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("LOG AWAKEEEEEEEEEEEEEEEE  PLAYER");
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }


    public void MovePlayer(Vector3 targetPosition)
    {
        this.transform.position = new Vector3(targetPosition.x, transform.position.y,targetPosition.z); // movemos el player a la ubicacion que se pasa
    }
}

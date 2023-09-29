using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCamaraConMouse : MonoBehaviour
{



    public float CamaraSenbility = 30;
    public Rigidbody RbCurrentObject;
    public GameObject Target;

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        //Debug.Log("MOUSE X " + mouseX + "MOUSE Y " + mouseY);
        Quaternion camaraTotation = transform.rotation;
        transform.Rotate( 0, mouseX, 0);
        Camera.main.transform.Rotate(-mouseY, 0, 0);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 900, Color.cyan);        
        if(Physics.Raycast(ray, out var hitInfo))
        {
            if(hitInfo.transform.TryGetComponent<Rigidbody>(out var rbComponet))
            {
                RbCurrentObject = rbComponet;                
            }
        }


        if(RbCurrentObject != null)
        {
            RbCurrentObject.velocity = (-RbCurrentObject.transform.position + Target.transform.position).normalized * 1;
        }

    }

}

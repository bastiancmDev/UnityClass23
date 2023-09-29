using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsTesting : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public GameObject Cubo2;
    public Coroutine CurrentCoroutine;

    public LayerMask layer;
    void Start()
    {        
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //  StartFollowCube();

        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(raycast, float.MaxValue, layer, QueryTriggerInteraction.UseGlobal);
        foreach (var hit in hits)
        {
            //Debug.Log( hit.transform.name + " LA DISTANCIA ES :"  + Vector3.Distance(raycast.origin, hit.transform.position));
        }

        Debug.DrawLine(raycast.origin, transform.forward * 200, Color.blue);


    }


    public void StartFollowCube()
    {
        if(CurrentCoroutine != null)
        {
            CurrentCoroutine = StartCoroutine(FollowCube());
        }        
    }

    public void StopCoroutine()
    {
        StopCoroutine(CurrentCoroutine);
        CurrentCoroutine = null;
    }


    

 
    IEnumerator FollowCube()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            Vector3 direction = Cubo2.transform.position - transform.position;
            rb.AddForce(direction.normalized * 1, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }


}

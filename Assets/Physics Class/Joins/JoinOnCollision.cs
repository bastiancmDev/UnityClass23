using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinOnCollision : MonoBehaviour
{
    public FixedJoint FixedJoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        FixedJoint = gameObject.AddComponent<FixedJoint>();
        var rbOncolllison = collision.rigidbody;
        FixedJoint.connectedBody = rbOncolllison;
    }
}

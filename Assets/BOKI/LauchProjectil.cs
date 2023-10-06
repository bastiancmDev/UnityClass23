using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauchProjectil : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float force;

    public Transform direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce((-transform.position  - direction.position).normalized * force, ForceMode.Acceleration);
        }
    }
}

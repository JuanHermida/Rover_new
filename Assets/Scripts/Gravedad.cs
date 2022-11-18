using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad : MonoBehaviour
{
    public Rigidbody rb;
    public float gMoon = 1.62f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * gMoon); //o
    }
}

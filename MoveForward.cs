using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveForward : MonoBehaviour
{
    Rigidbody2D rb;

    public float rotationSpeed;
    public float moveForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z - rotationSpeed * Input.GetAxis("Horizontal"));
        }

    }

    private void FixedUpdate()
    {
        //if (Input.GetAxis("Vertical") != 0)
        //{
        //    rb.AddForce(transform.up * moveForce * Input.GetAxis("Vertical"));
        //}

    }
}

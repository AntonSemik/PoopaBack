using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoopaFly : MonoBehaviour
{

    public float speed = 10.0f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rb.AddForce(-transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Borders"))
        {
            gameObject.SetActive(false);
        }
    }
}

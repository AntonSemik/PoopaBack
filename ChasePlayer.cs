using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float chaseSpeed = 10;
    Transform player;
    Vector3 direction;

    public Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        direction = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(transform.forward,direction);

        rb.velocity = direction.normalized * chaseSpeed;
    }
}

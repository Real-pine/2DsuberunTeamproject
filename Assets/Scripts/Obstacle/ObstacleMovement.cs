using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 10;

    private void ApplyMovement()
    {
        rb.velocity = Vector3.down * moveSpeed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.y < -6.0f) Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }
}

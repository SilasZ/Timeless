using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 1;
    public float movementAcceleration = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > movementSpeed) return;
        Settings s = FindObjectOfType<Settings>();
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(s.moveUp))
            moveDirection = moveDirection + Vector3.up;
        if (Input.GetKey(s.moveDown))
            moveDirection = moveDirection + Vector3.down;
        if (Input.GetKey(s.moveLeft))
            moveDirection = moveDirection + Vector3.left;
        if (Input.GetKey(s.moveRight))
            moveDirection = moveDirection + Vector3.right;

        Vector3 force = moveDirection * movementAcceleration * Time.deltaTime;
        rb.AddForce(force);
    }
}

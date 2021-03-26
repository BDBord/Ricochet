using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    public Vector2 direction;
    //float moveSpeed = 2f;
    //private float moveDirection;

    private void Awake()
    {
        //rb = transform.GetComponent<Rigidbody2D>();
        //boxCollider = transform.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        direction = MousePos - bowPos;
        FaceMouse();

        //moveDirection = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //Move();
    }

    void FaceMouse()
    {
        transform.right = direction;
    }

    /*void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }*/
}

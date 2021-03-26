using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        trackMovement();
    }

    void trackMovement()
    {
        direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /* Use this destroy function to delete arrow after certain conditions have been met */

        //Destroy(gameObject);

        /* */
        
        //hasHit = true;
        //rb.velocity = Vector2.zero;
        //rb.isKinematic = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    bool hasHit = false;
    public float initialColliderDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Arrow will be disabled for a short period after spawning. This is to prevent collision with player
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(DisableCollider());
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(initialColliderDelay);
        GetComponent<BoxCollider2D>().enabled = true;
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
        //Did you forget to finish this?
        if (!collision.gameObject.tag.Equals("Environment") && !hasHit)
        {
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            AudioManager.instance.Stop("Fly");
            AudioManager.instance.Play("Thunk");
        }

    }
}

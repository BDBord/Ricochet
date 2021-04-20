using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float range = 4;
    public float force = 50;
    private BoxCollider2D blowCollider; //The collider that "blows" objects
    private BoxCollider2D solidCollider;

    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach(Collider2D col in colliders)
        {
            if(col.isTrigger)
            {
                blowCollider = (BoxCollider2D)col;
            }
            else
            {
                solidCollider = (BoxCollider2D)col;
            }
        }

        setRange(range);
    }
    
    void FixedUpdate()
    {
        List<Collider2D> touching = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = false;

        if(blowCollider.OverlapCollider(filter, touching) > 0)
        {
            foreach(Collider2D col in touching)
            {
                Vector2 blowVector = transform.up;
                blowVector.Normalize();
                blowVector = blowVector * force;
                col.attachedRigidbody.AddForce(blowVector);
            }
        }
    }

    public void setRange(float newRange)
    {
        

        if(newRange != range)
        {
            range = newRange;
        }

        //Base offset (range = 0) is the solidCollider's size.y / 2, plus an arbitrary amount (0.05) to separate the colliders
        //This is calculated every time this method is called to avoid issues with adjusting solidCollider's size
        //Add range / 2, since range is entire height, and offet is in middle
        Vector2 newValues = new Vector2(0f, (solidCollider.size.y / 2f) + 0.05f + newRange / 2f);
        blowCollider.offset = newValues;
        newValues = new Vector2(blowCollider.size.x, newRange);
        blowCollider.size = newValues;
    }
}

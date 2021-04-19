/*
 * To Implement: 
 * Add this script as a component to an object that should be destroyed.
 * If the object is contains children, add it to the parent object and use Inspector to specify which object(s) should destroyed in destroyableObject[]
 * Otherwise, specify itself as destroyableObject (ie this.gameObject = destroyableObject)
 * Add rigidbody component (required for collision detection). Kinematic if unmoving, dynamic if moving.
 * movesAfterDestruction specifies whether the object should move after the relevant object is destroyed (ie switch rigidbody to dynamic)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnvironment : MonoBehaviour
{
    public bool movesAfterDestruction;
    public GameObject destroyableObject;

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Will only activate if it is hit by arrow AND the collider belongs to the (child) object that should be destroyable
        if (col.collider.gameObject.tag.Equals("Arrow") && col.otherCollider.gameObject == destroyableObject)
        {
            Destroy(col.collider.gameObject);
            Destroy(destroyableObject);

            if(movesAfterDestruction)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}

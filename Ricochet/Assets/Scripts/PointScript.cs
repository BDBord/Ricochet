using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    [HideInInspector]
    public bool hasHitCollider = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.isTrigger)
        {
            hasHitCollider = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            hasHitCollider = false;
        }
    }
}

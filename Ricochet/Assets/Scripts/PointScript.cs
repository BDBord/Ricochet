using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public bool hasHitCollider = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        hasHitCollider = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        hasHitCollider = false;
    }
}

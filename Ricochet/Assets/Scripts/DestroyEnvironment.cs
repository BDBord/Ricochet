using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnvironment : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Arrow"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject blood;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Arrow"))
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
            ShootArrow.arrowCount++;
            ShootArrow.EnemyNumber--;
        }

        if (col.gameObject.tag.Equals("Environment"))
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
            ShootArrow.arrowCount++;
            ShootArrow.EnemyNumber--;
        }

    }
}

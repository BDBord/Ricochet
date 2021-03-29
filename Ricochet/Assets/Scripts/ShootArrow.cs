using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShootArrow : MonoBehaviour
{
    public static int arrowCount = 1;

    public float LaunchForce;

    public GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (arrowCount == 0)
            {
                SceneManager.LoadScene(1);
                arrowCount++;
            }

            else
            {
                ArrowShoot();
                arrowCount--;
            }
           
        }

        
    }

    void ArrowShoot()
    {
        GameObject ArrowIns = Instantiate(Arrow, transform.position, transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
    }
}

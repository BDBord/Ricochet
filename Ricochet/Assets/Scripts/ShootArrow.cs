using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShootArrow : MonoBehaviour
{
    public static int arrowCount = 1;

    public float LaunchForce;

    public GameObject Arrow;

    private PlayerMovement playermove;

    public int numberofEnemies;

    public static int EnemyNumber;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playermove = player.GetComponent<PlayerMovement>();
        EnemyNumber = numberofEnemies;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (arrowCount == 0)
            {
                SceneManager.LoadScene(3);
                arrowCount++;
            }

            else if (EnemyNumber == 0)
            {
                SceneManager.LoadScene(4);
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
        if (playermove.m_FacingRight)
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + .1f;
            GameObject ArrowIns = Instantiate(Arrow, pos, transform.rotation);
            ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - .1f;
            GameObject ArrowIns = Instantiate(Arrow, pos, transform.rotation);
            ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        }
    }
}

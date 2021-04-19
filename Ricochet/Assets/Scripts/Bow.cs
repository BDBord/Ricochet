using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    
    Vector2 direction;
    public float force;
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberofPoints;
    private PlayerMovement playermove;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playermove = player.GetComponent<PlayerMovement>();

        Points = new GameObject[numberofPoints];
        for (int i = 0; i < numberofPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        direction = MousePos - bowPos;
        FaceMouse();
        
        /*for(int i = 0; i<Points.Length; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
        }*/

        //Updates points' position to match trajectory each frame, disables sprite renderer if collider is hit
        bool collided = false;
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].transform.position = PointPosition((i + 1) * 0.1f);
            if (Points[i].GetComponent<PointScript>().hasHitCollider)
            {
                collided = true;
            }
            Points[i].GetComponent<SpriteRenderer>().enabled = !collided;
        }
    }

    

    void FaceMouse()
    {
        if(playermove.m_FacingRight == true)
        {
            transform.right = direction;
        }
        else
        {
            transform.right = -direction;
        }
        
    }

    Vector2 PointPosition (float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
}

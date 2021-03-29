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

    void Start()
    {
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

        for (int i = 0; i<Points.Length; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
        }
    }

    

    void FaceMouse()
    {
        transform.right = direction;
    }

    Vector2 PointPosition (float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
}

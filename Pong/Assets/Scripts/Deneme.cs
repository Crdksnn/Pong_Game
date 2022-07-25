using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform p4;
    
    void Start()
    {
        
    }
    
    void Update()
    {

        Vector2 posP1 = new Vector2(p1.position.x, p1.position.y);
        Vector2 posP2 = new Vector2(p2.position.x, p2.position.y);
        Vector2 posP3 = new Vector2(p3.position.x, p3.position.y);
        Vector2 posP4 = new Vector2(p4.position.x, p4.position.y);

        if(Math2d.LineSegmentsIntersection(posP1,posP2,posP3,posP4))
        {
            Debug.Log("Kesisiyor");
        }    
    }
}

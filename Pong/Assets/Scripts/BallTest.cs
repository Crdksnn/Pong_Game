using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{
    public Vector2 velocityDir;
    public float speed;
    
    [SerializeField] private Transform block1;
    [SerializeField] private Transform block2;

    public List<Vector2> bounds = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bounds.Clear();
        UpdateWall(block1);
        UpdateWall(block2);

        var pos = (Vector2)transform.position;
        var movement = velocityDir * speed * Time.deltaTime;

        var newPos =pos+ movement;
        if (FindIntersect(pos, pos+movement, out var intersection))
        {
            velocityDir.x = -velocityDir.x;
            newPos = intersection + velocityDir*transform.localScale.x;
        }

        transform.position = newPos;
    }


    public bool FindIntersect(Vector3 ballCenter, Vector3 ballMovement,out Vector2 intersection)
    {
        for (int i = 0; i < bounds.Count; i+=2)
        {
            if (Math2d.LineSegmentsIntersection(ballCenter, ballMovement, bounds[i], bounds[i+1], out intersection))
            {
                return true;
            }
        }

        intersection = new Vector2();
        return false;
    }

    public void UpdateWall(Transform wall)
    {
        Vector3 upPoint = wall.position;
        upPoint.y += wall.localScale.y / 2;
        upPoint.x += wall.localScale.y / 2;
        
        Vector3 downPoint = wall.position;
        downPoint.y -= wall.localScale.y / 2;
        
        bounds.Add(upPoint);
        bounds.Add(downPoint);
    }
}

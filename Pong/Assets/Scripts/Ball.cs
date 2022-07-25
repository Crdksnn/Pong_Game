using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Transform block1;
    [SerializeField] private Transform block2;
    [SerializeField] private float velocity;
    private int direction = -1;
    
    private Vector2 block1BoundryBottom;
    private Vector2 block1BoundryTop;

    private Vector2 block2BoundryBottom;
    private Vector2 block2BoundryTop;
    
    private Vector2 ballLeftStart;
    private Vector2 ballLeftEnd;
    
    private Vector2 ballRightStart;
    private Vector2 ballRightEnd;
    
    private UIController uiCotroller;
    
    void Start()
    {
        uiCotroller = UIController.instance;
    }

    void Update()
    {

        ballLeftStart = new Vector2(transform.position.x - .5f, transform.position.y);
        ballLeftEnd = new Vector2(transform.position.x - .5f - Mathf.Abs(velocity) * Time.deltaTime, transform.position.y);

        ballRightStart = new Vector2(transform.position.x + .5f, transform.position.y);
        ballRightEnd = new Vector2(transform.position.x + .5f + Mathf.Abs(velocity) * Time.deltaTime, transform.position.y);

        block1BoundryBottom = new Vector2(block1.position.x + .5f, block1.position.y - 2);
        block1BoundryTop = new Vector2(block1.position.x + .5f, block1.position.y + 2);

        block2BoundryBottom = new Vector2(block2.position.x - .5f, block2.position.y - 2);
        block2BoundryTop = new Vector2(block2.position.x - .5f, block2.position.y + 2);

        if (velocity < 0)
        {

            if (Math2d.LineSegmentsIntersection(ballLeftStart, ballLeftEnd, block1BoundryBottom, block1BoundryTop))
            {
                velocity = -velocity;
            }

            else
            {
                transform.position += Vector3.right * velocity * Time.deltaTime;
            }

        }

        if (velocity > 0)
        {

            if (Math2d.LineSegmentsIntersection(ballRightStart, ballRightEnd, block2BoundryBottom, block2BoundryTop))
            {
                velocity = -velocity;
            }

            else
            {
                transform.position += Vector3.right * velocity * Time.deltaTime;
            }
        }


    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    
    [Header("Block Control")]
    [SerializeField] private bool block1Control;
    [SerializeField] private bool block2Control;
    [SerializeField] private bool automode;
    
    [SerializeField] private Transform ball;

    
    void Update()
    {
        Move();
     
    }
    
    private void Move()
    {
        if (block1Control)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime );
            
                if (transform.position.y >= 8)
                    transform.position = new Vector2(transform.position.x, 8);
            }
        
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            
                if (transform.position.y <= 2)
                    transform.position = new Vector2(transform.position.x, 2);
            }
        }
        
        if (block2Control)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime );
            
                if (transform.position.y >= 8)
                    transform.position = new Vector2(transform.position.x, 8);
            }
        
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            
                if (transform.position.y <= 2)
                    transform.position = new Vector2(transform.position.x, 2);
            }
        }

        if (automode)
        {
            transform.position = new Vector2(transform.position.x, ball.position.y);
            
            if (transform.position.y >= 8)
                transform.position = new Vector2(transform.position.x, 8);
            
            if (transform.position.y <= 2)
                transform.position = new Vector2(transform.position.x, 2);
        }
        
        
    }
    
}

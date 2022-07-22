using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Transform block1;
    [SerializeField] private Transform block2;
    [SerializeField] private float velocity;

    private int upDirection = -1;
    private int rightDirection = -1;
    
    private UIController uiCotroller;
    
    void Start()
    {
        uiCotroller = UIController.instance;
    }
    
    void Update()
    {
        
        //transform.position += transform.right * velocity * Time.deltaTime * rightDirection + transform.up * velocity * upDirection * Time.deltaTime;
        transform.position += transform.right * velocity * Time.deltaTime * rightDirection;
        
        if ((transform.position.x <= block1.position.x + .4f + .5f) && (block1.transform.position.y - 2 <= transform.position.y && transform.position.y <= block1.transform.position.y + 2) )
            rightDirection = 1;
        
        if ((transform.position.x >= block2.position.x - .4f - .5f) && (block2.transform.position.y - 2 <= transform.position.y && transform.position.y <= block2.transform.position.y + 2))
            rightDirection = -1;
        
        if (0.4 >= transform.position.y)
            upDirection = 1;

        if (transform.position.y >= 9.6)
            upDirection = -1;
        
        if (transform.position.x <= -9.5)
        {
            uiCotroller.Block2Score();
            Destroy(gameObject);
        }
        
        if (transform.position.x >= 9.5)
        {
            uiCotroller.Block1Score();
            Destroy(gameObject);
        }
    
    }
    
}

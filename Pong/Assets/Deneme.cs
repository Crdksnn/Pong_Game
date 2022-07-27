using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{

    [SerializeField] private float velocity;

    [SerializeField] private Transform block1;
    [SerializeField] private Transform block2;

    private Vector2 _ballLeft;
    private Vector2 _ballRight;

    private Vector2 _block1BottomBoundry;
    private Vector2 _block1TopBoundry;

    private Vector2 _block2BottomBoundry;
    private Vector2 _block2TopBoundry;

    private Vector2 _currentBlockBottomBoundry;
    private Vector2 _currentBlockTopBoundry;

    private bool key = true;

    Transform imagePos;
    [SerializeField] private GameObject imagePrefab;
    
    void Start()
    {
        
    }
        
        
    void Update()
    {
        
        _ballLeft = new Vector2(transform.position.x - velocity * Time.deltaTime,transform.position.y);
        _ballRight = new Vector2(transform.position.x + velocity * Time.deltaTime, transform.position.y);

        _block1BottomBoundry = new Vector2(block1.transform.position.x + .5f, transform.position.y - 2f);
        _block1TopBoundry = new Vector2(block1.transform.position.x + .5f, transform.position.y + 2f);
        
        _block2BottomBoundry = new Vector2(block2.transform.position.x - .5f, transform.position.y - 2f);
        _block2TopBoundry = new Vector2(block2.transform.position.x - .5f, transform.position.y + 2f);

        _currentBlockBottomBoundry = CurrentBlockBottomBundry();
        _currentBlockTopBoundry = CurrentBlockTopBoundry();
        
        if (Math2d.LineSegmentsIntersection(_ballLeft, _ballRight, _currentBlockBottomBoundry, _currentBlockTopBoundry, out Vector2 intersection))
        {
            ChangeBoundry();
            
            velocity = -velocity;
            //Instantiate(imagePrefab, new Vector3(intersection.x,intersection.y,0), Quaternion.identity);
            transform.position = new Vector3(intersection.x , intersection.y, 0);
        }

        else
        {
            Movement();
        }

    }
    
    
    Vector2 CurrentBlockBottomBundry()
    {
        if (key)
        {
            _currentBlockBottomBoundry = _block1BottomBoundry;
            return _currentBlockBottomBoundry;
        }
        
        else
        {
            _currentBlockBottomBoundry = _block2BottomBoundry;
            return _currentBlockBottomBoundry;
        }
        
    }

    Vector2 CurrentBlockTopBoundry()
    {
        if (key)
        {
            _currentBlockTopBoundry = _block1TopBoundry;
            return _currentBlockTopBoundry;
        }
        
        else
        {
            _currentBlockTopBoundry = _block2TopBoundry;
            return _currentBlockTopBoundry;
        }
    }
    
    private void ChangeBoundry()
    {
        if (key)
        {
            _currentBlockBottomBoundry = _block1BottomBoundry;
            _currentBlockTopBoundry = _block1TopBoundry;
            key = false;
        }

        else
        {
            _currentBlockBottomBoundry = _block2BottomBoundry;
            _currentBlockTopBoundry = _block2TopBoundry;
            key = true;
        }
    }

    private void Movement()
    {
        transform.position += Vector3.left * velocity * Time.deltaTime;
    }
}

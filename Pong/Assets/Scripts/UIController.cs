using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private TextMeshProUGUI block1Text;
    [SerializeField] private TextMeshProUGUI block2Text;
    
    private int block1Score = 0;
    private int block2Score = 0;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Block1Score()
    {
        
        block1Score++;
        block1Text.text = block1Score.ToString();
    }
    
    public void Block2Score()
    {
        
        block2Score++;
        block2Text.text = block2Score.ToString();
    }
    
}

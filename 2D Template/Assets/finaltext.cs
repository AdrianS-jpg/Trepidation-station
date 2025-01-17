using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class finaltext : MonoBehaviour
{
    public int points;
    private Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
        Text.text = "Points: " + points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

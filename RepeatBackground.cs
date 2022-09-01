using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float resetPos;

    private void Start()
    {
        startPosition = transform.localPosition;
        resetPos = GetComponent<BoxCollider>().size.x / 2;
        // print("start pos is " + startPosition +"; size is " + GetComponent<BoxCollider>().size.x + "; resetPos is " + resetPos);
        //THIS METHOD ONLY WORKS IF THE GAME OBJECT IS SCALED a certain way (works at scale of 1, 2, 4)
    }

    private void FixedUpdate() //bad code
    {
        if (transform.position.y < startPosition.y - resetPos || transform.position.y > startPosition.y + resetPos)
        {
            float temp = startPosition.x - resetPos;
            // print("reset when x="+temp);
            transform.position = startPosition;
            
        }

    }
}

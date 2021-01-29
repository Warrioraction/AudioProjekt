using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{ 
    public float speed;
    public float distance;
    public bool inverted;
    private float xStartPosition;
  
    void Start () {
        xStartPosition = transform.position.x;
    }
    void Update () {
        if (!inverted)
        {
            if ((speed < 0 && transform.position.x < xStartPosition) ||
                (speed > 0 && transform.position.x > xStartPosition + distance))
            {
                speed *= -1;
            }
        }
        else
        {
            if ((speed > 0 && transform.position.x > xStartPosition) ||
                (speed < 0 && transform.position.x < xStartPosition - distance))
            {
                speed *= -1;
            }
        }

        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool inverted;
    private float yStartPosition;
  
    void Start () {
        yStartPosition = transform.position.y;
    }
    void Update () {
        if (!inverted)
        {
            if ((speed < 0 && transform.position.y < yStartPosition) ||
                (speed > 0 && transform.position.y > yStartPosition + distance))
            {
                speed *= -1;
            }
        }
        else
        {
            if ((speed > 0 && transform.position.y > yStartPosition) ||
                (speed < 0 && transform.position.y < yStartPosition - distance))
            {
                speed *= -1;
            }
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }
}

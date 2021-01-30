using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool inverted;
    private float xStartPosition;
    private SpriteRenderer renderer;
  
    void Start () {
        xStartPosition = transform.position.x;
        renderer = GetComponent<SpriteRenderer>();
    }
    void Update () {
        if (!inverted)
        {
            if (speed < 0 && transform.position.x < xStartPosition)
            {
                renderer.flipX = false;
                speed *= -1;
            }  
            else if (speed > 0 && transform.position.x > xStartPosition + distance)
            {
                renderer.flipX = true;
                speed *= -1;
            }
        }
        else
        {
            if (speed > 0 && transform.position.x > xStartPosition)
            {
                renderer.flipX = true;
                speed *= -1;
            }  
            else if (speed < 0 && transform.position.x < xStartPosition - distance)
            {
                renderer.flipX = false;
                speed *= -1;
            }
        }

        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

}

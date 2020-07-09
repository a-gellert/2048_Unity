using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBack : MonoBehaviour
{
    private int edge = 80;
    private float speedX;
    private float speedY;
    private void Start()
    {
        speedX = Random.Range(2f, 5f);
        speedY = Random.Range(2f, 5f);
    }
    private void Update()
    {
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        if (transform.position.x > edge)
        {
            speedX = -speedX;
        }
        if (transform.position.x < -edge)
        {
            speedX = Random.Range(2f, 5f);
        }
        if (transform.position.y > edge)
        {
            speedY = -speedY;
        }
        if (transform.position.y < -edge)
        {
            speedY = Random.Range(2f, 5f);
        }
    }
}

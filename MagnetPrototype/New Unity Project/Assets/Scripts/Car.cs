using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    float Velocity;
 
    // Use this for initialization
    void Start()
    {
        Velocity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = Velocity += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.left), currentSpeed /= (Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.right), currentSpeed *= Velocity * Time.deltaTime);
        }
    }
}

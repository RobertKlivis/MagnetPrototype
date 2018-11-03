using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    float Velocity;

    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public float maxreverseSpeed;

    private float currentSpeed = 0.0f;
    private float reverseSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {
        Velocity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       // float currentSpeed = Velocity += Time.deltaTime;

        currentSpeed += acceleration * Time.deltaTime;
        reverseSpeed += deceleration * Time.deltaTime;

        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }

        if (reverseSpeed > maxreverseSpeed)
        {
            reverseSpeed = maxreverseSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.left), reverseSpeed * Time.deltaTime);
            currentSpeed = 0;

            // transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.left), currentSpeed /= (Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.right), currentSpeed * Time.deltaTime);
            reverseSpeed = 0;

            // transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.right), currentSpeed *= Velocity * Time.deltaTime);
        }
    }
}

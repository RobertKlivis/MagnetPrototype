using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public float maxreverseSpeed;
    public GameObject Respawn;

    public Vector2 vGravity;

    private float gravity = 9.81f;

    private float currentSpeed = 0.0f;
    private float reverseSpeed = 0.0f;

    private Vector2 Spawn;

    // Use this for initialization
    void Start()
    {

        vGravity = Vector2.down * gravity;
        Spawn = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

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
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.right), currentSpeed * Time.deltaTime);
            reverseSpeed = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Respawn")
        {
            transform.position = Spawn;
        }
    }
}

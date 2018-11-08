using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public float maxreverseSpeed;
	public float Tilt;
    public GameObject Respawn;
    public GameObject Ground;

    public Vector2 vGravity;

	private Vector2 Spawn;

    private float gravity = 9.81f;
    private float currentSpeed = 0.0f;
    private float reverseSpeed = 0.0f;

    public bool onGround = false;
    public bool useMagnet = false;

    // Use this for initialization
    void Start()
    {

        vGravity = Vector2.down * gravity;
        Spawn = transform.position;

        onGround = false;

        useMagnet = false;

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
            if (onGround == true)
            {
                transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.left), reverseSpeed * Time.deltaTime);
                currentSpeed = 0;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (onGround == true)
            {
                transform.position = Vector2.Lerp(transform.position, transform.TransformPoint(Vector2.right), currentSpeed * Time.deltaTime);
                reverseSpeed = 0;
            }
        }


        //For testing

        if (Input.GetKey(KeyCode.R))
        {
            Tilt += Time.deltaTime * -10;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Tilt);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            acceleration = 100;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "Respawn")
        {
            transform.position = Spawn;
			Tilt += Time.deltaTime * -10;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, Tilt);
			currentSpeed = 0;
			reverseSpeed = 0;
        }

        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            currentSpeed = 10;
            reverseSpeed = 0;
        }

        if (other.gameObject.tag == "Bridge")
        {
            onGround = true;
            currentSpeed = 10;
            reverseSpeed = 0;
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
            currentSpeed = 20;
            reverseSpeed = 0;
        }

        if (other.gameObject.tag == "Bridge")
        {
            onGround = false;
            currentSpeed = 20;
            reverseSpeed = 0;
        }

    }
}

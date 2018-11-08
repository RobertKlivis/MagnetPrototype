using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour {

    public float rotateSpeed = 10.0f;

    public GameObject Car;

    // Use this for initialization
    void Start()
    {

        GameObject Car = GameObject.Find("Car");
        CarScript carScript = Car.GetComponent<CarScript>();
        carScript.onGround = false;

    }

    // Update is called once per frame
    void Update()
    {

        float move = Input.GetAxis("Horizontal");

        if (move < 0 || move > 0) transform.Rotate(Vector3.forward * -rotateSpeed);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        GameObject Car = GameObject.Find("Car");
        CarScript carScript = Car.GetComponent<CarScript>();
        carScript.onGround = false;

        if (other.gameObject.tag == "Ground")
        {
            carScript.onGround = true;
        }

        if (other.gameObject.tag == "Bridge")
        {
            carScript.onGround = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {

        GameObject Car = GameObject.Find("Car");
        CarScript carScript = Car.GetComponent<CarScript>();
        carScript.onGround = false;

        if (other.gameObject.tag == "Ground")
        {
            carScript.onGround = false;
        }

        if (other.gameObject.tag == "Bridge")
        {
            carScript.onGround = false;
        }

    }

}

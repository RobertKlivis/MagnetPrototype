using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour {

    public GameObject bridge;

    private Vector3 newPos;
    private float smooth = 3;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    void ChangingPosition()
    {
        // Positions that the bridge will interpolate to. 
        Vector3 A = bridge.transform.position;
        Vector3 bridgeLandingPosition = new Vector3 (47, 0.3f, 0); // Final position when the bridge is knocked down by the car
       // Quaternion bridgeLandingRotation = new Quaternion(0, 0, 0, 0);

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("bridge moving");
            newPos = bridgeLandingPosition;
            transform.position = Vector3.Lerp(bridge.transform.position, newPos, Time.deltaTime * smooth);
        }

        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Bridge")
        {
            Debug.Log("bridge hit");
            ChangingPosition();
            /* gameObject.transform.rotation = Quaternion.Euler(0, 0, Tilt);
             gameObject.transform.position = new Vector3(48.0f, -0.55f);
             */ // These lines of code are automatically translating the bridge
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bridge")
        {
            Debug.Log("bridge hit");
            ChangingPosition();
        }
    }

}

//Link to lerp tutorial referenced in this script: https://www.youtube.com/watch?v=cD-mXwSCvWc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour {

    public float Tilt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Car")
        {
            Tilt += Time.deltaTime * -10;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Tilt);
            gameObject.transform.position = new Vector3(48.0f, -0.55f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class as_animation : MonoBehaviour {

    public float tumble;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

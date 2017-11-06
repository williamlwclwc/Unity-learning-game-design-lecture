using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_laser_move_ctrl : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

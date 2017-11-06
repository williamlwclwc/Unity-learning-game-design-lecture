using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    public float time=1.51f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

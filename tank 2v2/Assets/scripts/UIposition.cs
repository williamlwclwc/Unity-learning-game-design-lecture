using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIposition : MonoBehaviour {

    public bool use_up_to_date_rotation = true;
    private Quaternion up_to_date_rotation;

	// Use this for initialization
	void Start () {
        up_to_date_rotation = transform.parent.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(use_up_to_date_rotation)
        {
            transform.rotation = up_to_date_rotation;
        }
	}
}

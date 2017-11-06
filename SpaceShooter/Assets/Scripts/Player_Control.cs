using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMax, xMin, zMax, zMin;
}
public class Player_Control : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    private float nextfire;
    public float firerate;
    public GameObject shot;
    public Transform Shot_position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)&&Time.time>nextfire)
        {
            nextfire = firerate + Time.time;
            Instantiate(shot, Shot_position.position, Shot_position.rotation);
            GetComponent<AudioSource>().Play();
        }
	}

    private void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(move_horizontal, 0, move_vertical);
        GetComponent<Rigidbody>().velocity = speed * movement;
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0,Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax));
    }
}

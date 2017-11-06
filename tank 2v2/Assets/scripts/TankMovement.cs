using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    public float speed=5;
    public float angularspeed=10;
    public int number;
    private Rigidbody rigidbody;
    public AudioClip idle;
    public AudioClip driving;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float v = Input.GetAxis("Vertical"+"P"+number);
        rigidbody.velocity = transform.forward * v * speed;
        float h = Input.GetAxis("Horizontal"+"P"+number);
        rigidbody.angularVelocity = transform.up * h * angularspeed;
        if(Mathf.Abs(h)>0.1||Mathf.Abs(v)>0.1)
        {
            audio.clip = driving;
        }
        else
        {
            audio.clip = idle;
        }
        if (audio.isPlaying == false)
        {
            audio.Play();
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAtk : MonoBehaviour {

    private Transform Fire_point;
    public GameObject shellprefab;
    public KeyCode firekey=KeyCode.Space;
    public float shellspeed = 10;
    public AudioClip fire;
	// Use this for initialization
	void Start () {
        Fire_point = transform.Find("Fire_point");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(firekey))
        {
           GameObject go = GameObject.Instantiate(shellprefab, Fire_point.position, Fire_point.rotation) as GameObject;
            AudioSource.PlayClipAtPoint(fire,transform.position);
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellspeed;
        }
	}
}

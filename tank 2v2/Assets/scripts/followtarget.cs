using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followtarget : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public Vector3 offset;
    private Camera camera;
	// Use this for initialization
	void Start () {
        offset = transform.position - (player1.position + player2.position) / 2;
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player1 == null || player2 == null) return;
        transform.position = offset + (player1.position + player2.position);
        float distance = Vector3.Distance(player1.position, player2.position);
        float size = distance * 0.6f;
        camera.orthographicSize = size;
	}
}

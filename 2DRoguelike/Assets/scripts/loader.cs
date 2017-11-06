using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loader : MonoBehaviour {

    public GameObject gameManager;

	// Use this for initialization
	void Awake () {
        if (Gamemanager.Instance == null)
        {
            GameObject.Instantiate(gameManager);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

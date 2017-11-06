using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour {

    public GameObject shellExplosionprefab;
    public AudioClip audio;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(audio,transform.position);
        GameObject.Instantiate(shellExplosionprefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
        if(collider.tag=="Tank")
        {
            collider.SendMessage("take_damage");
        }
    }
}

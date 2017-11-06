using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_isshot : MonoBehaviour {

    private Game_control game_ctrl;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        GameObject game_ctrl_obj = GameObject.FindWithTag("Game_control");
        game_ctrl = game_ctrl_obj.GetComponent<Game_control>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        game_ctrl.Gameover();
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

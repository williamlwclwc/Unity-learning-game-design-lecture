using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_collision : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerexplosion;
    public int score=1;
    private Game_control game_ctrl;

    void Start()
    {
        GameObject game_ctrl_obj = GameObject.FindWithTag("Game_control");
        game_ctrl = game_ctrl_obj.GetComponent<Game_control>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Boundary"||other.tag=="asteroids")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag=="Player")
        {
            Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
            game_ctrl.Gameover();
        }
        game_ctrl.addscore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

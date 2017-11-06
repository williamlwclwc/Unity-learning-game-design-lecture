using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall1 : MonoBehaviour {

    public int hp = 2;
    public Sprite DmgSprite;
 
    public void DamageWall()
    {
        hp -= 1;
        GetComponent<SpriteRenderer>().sprite = DmgSprite;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}


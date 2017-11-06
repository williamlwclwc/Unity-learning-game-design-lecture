using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1 : MonoBehaviour {

    public float smoothing = 1;
    public float restTime = 1;
    private float restTimer = 0;

    public AudioClip chop1, chop2;
    public AudioClip footstep1,footstep2;
    public AudioClip fruit1, fruit2, soda1, soda2;
    [HideInInspector]public Vector2 targetpos=new Vector2(1,1);
    private Rigidbody2D rigidbody1;
    private BoxCollider2D collider;
    private Animator animator;

	// Use this for initialization
	void Start () {
        rigidbody1 = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody1.MovePosition(Vector2.Lerp(transform.position, targetpos, smoothing * Time.deltaTime));
        if (Gamemanager.Instance.food <= 0||Gamemanager.Instance.win==true)
        {
            return;
        }
        restTimer += Time.deltaTime;
        if (restTimer < restTime) return;
        //keyboard input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if(h>0)
        {
            v = 0;
        }
        if (h != 0||v!=0)
        {
            //detect collision
            collider.enabled = false;
            RaycastHit2D hit=Physics2D.Linecast(targetpos,targetpos+new Vector2(h,v));
            collider.enabled = true;
            if(hit.transform==null)
            {
                //move
                targetpos += new Vector2(h, v);
                audiomanager.Instance.RandomPlay(footstep1, footstep2);
                //consume food when move
                Gamemanager.Instance.Reducefood(1);
            }
            else
            {
                switch(hit.collider.tag)
                {
                    case "outwall":
                        break;
                    case "wall":
                        animator.SetTrigger("atk");
                        audiomanager.Instance.RandomPlay(chop1, chop2);
                        hit.collider.SendMessage("DamageWall");
                        break;
                    case "Food":
                        Gamemanager.Instance.Addfood(10);
                        targetpos += new Vector2(h, v);
                        audiomanager.Instance.RandomPlay(footstep1, footstep2);
                        //consume food when move
                        Gamemanager.Instance.Reducefood(1);
                        Destroy(hit.transform.gameObject);
                        audiomanager.Instance.RandomPlay(fruit1, fruit2);
                        break;
                    case "Soda":
                        Gamemanager.Instance.Addfood(20);
                        targetpos += new Vector2(h, v);
                        audiomanager.Instance.RandomPlay(footstep1, footstep2);
                        //consume food when move
                        Gamemanager.Instance.Reducefood(1);
                        Destroy(hit.transform.gameObject);
                        audiomanager.Instance.RandomPlay(soda1, soda2);
                        break;
                    case "CPU":
                        break;
                    case "Exit":
                        targetpos += new Vector2(h, v);
                        audiomanager.Instance.RandomPlay(footstep1, footstep2);
                        //consume food when move
                        Gamemanager.Instance.Reducefood(1);
                        break;

                }
            }
            Gamemanager.Instance.p1move();
            Gamemanager.Instance.on_exit();
            restTimer = 0;
        }
        
	}
    public void damage(int losefood)
    {
        Gamemanager.Instance.Reducefood(losefood);
        animator.SetTrigger("damage");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpu : MonoBehaviour {

    private Vector2 targetPosition;
    private Transform player;

    private Rigidbody2D rigidbody;
    public float smoothing = 3;
    public int losefood = 10;
    private BoxCollider2D collider;
    private Animator animator;

    public AudioClip cpuatk;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        targetPosition = transform.position;
        Gamemanager.Instance.cpulist.Add(this);
    }
    void Update(){
        rigidbody.MovePosition(Vector2.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime));
    }
	public void Move()
    {
        Vector2 offset = player.position - transform.position;
        if(offset.magnitude<1.1f)
        {
            //attak
            animator.SetTrigger("cpatk");
            audiomanager.Instance.RandomPlay(cpuatk);
            player.SendMessage("damage",losefood);
        }
        else
        {
            float x = 0, y = 0;
            //pursuit
            if(Mathf.Abs(offset.y)>Mathf.Abs(offset.x))
            {
                //move along y
                if(offset.y<0)
                {
                    y = -1;
                }
                else
                {
                    y = 1;
                }
            }
            else
            {
                //move along x
                if(offset.x<0)
                {
                    x = -1;
                }
                else
                {
                    x = 1;
                }
            }
            //examine collision
            collider.enabled = false;
            RaycastHit2D hit = Physics2D.Linecast(targetPosition, targetPosition + new Vector2(x, y));
            collider.enabled = true;
            if(hit.transform==null)
            {
                targetPosition += new Vector2(x, y);
            }
            else
            {
                if(hit.collider.tag=="Food"||hit.collider.tag=="Soda")
                {
                    targetPosition += new Vector2(x, y);
                }
            }
        }
    }
		
	
}

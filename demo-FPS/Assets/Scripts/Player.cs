using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //玩家变量
    public Transform m_transform;
    CharacterController m_ch;
    float m_movespeed = 10.0f;
    float m_gravity = 2.0f;
    public int m_life = 5;

    //摄像机变量
    private Transform cam_transform;
    Vector3 m_camRot;
    float m_camHeight = 1.4f;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        m_ch = this.GetComponent<CharacterController>();

        cam_transform = Camera.main.transform;
        Vector3 pos = m_transform.position;
        pos.y += m_camHeight;
        cam_transform.position = pos;
        cam_transform.rotation = m_transform.rotation;
        m_camRot = cam_transform.eulerAngles;

        //锁定鼠标
        Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_life <= 0)
            return;
        Control();
	}

    void Control()
    {
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");

        m_camRot.x -= rv;
        m_camRot.y += rh;
        cam_transform.eulerAngles = m_camRot;

        Vector3 camrot = cam_transform.eulerAngles;
        camrot.x = 0;
        camrot.z = 0;
        m_transform.eulerAngles = camrot;

        float xm = 0, ym = 0, zm = 0;//x,y,z坐标值
        ym -= m_gravity * Time.deltaTime;//重力影响y坐标值
        //上下左右移动控制
        if(Input.GetKey(KeyCode.W))
        {
            zm += m_movespeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            zm -= m_movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xm += m_movespeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xm -= m_movespeed * Time.deltaTime;
        }
        //移动
        m_ch.Move(m_transform.TransformDirection(new Vector3(xm, ym, zm)));

        Vector3 pos = m_transform.position;
        pos.y += m_camHeight;
        cam_transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(this.transform.position, "Spawn.tif");
    }
}

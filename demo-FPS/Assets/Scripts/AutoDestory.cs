﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour {

    public float m_timer = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_timer -= Time.deltaTime;
        if(m_timer<=0)
        {
            Destroy(this.gameObject);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    int m_score = 0;
    static int m_highscore = 0;
    int m_ammo = 100;
    Player m_player;

    public Text ammo;
    public Text highscore;
    public Text life;
    public Text score;

	// Use this for initialization
	void Start () {
        Instance = this;
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        ammo = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Text>();
        highscore = GameObject.FindGameObjectWithTag("High_score").GetComponent<Text>();
        life = GameObject.FindGameObjectWithTag("HP").GetComponent<Text>();
        score = GameObject.FindGameObjectWithTag("Cur_score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int Score)
    {
        m_score += Score;
        score.text = "Current Score: " + m_score;
        if (m_score>m_highscore)
        {
            m_highscore = m_score;
            highscore.text = "High Score: " + m_highscore;
        }
    }

    public void SetAmmo(int Ammo)
    {
        m_ammo -= Ammo;
        if(m_ammo<=0)
        {
            m_ammo = 100 - m_ammo;
        }
        ammo.text = m_ammo.ToString() + "/100";
    }

    public void SetLife(int Life)
    {
        life.text = Life.ToString()+"%";
    }

    private void OnGUI()
    {
        if(m_player.m_life<=0)
        {
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 40;
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Game Over");
            GUI.skin.label.fontSize = 30;
            if (GUI.Button(new Rect(Screen.width * 0.5f - 150, Screen.height * 0.75f, 300, 40), "Try Again"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
    }
}

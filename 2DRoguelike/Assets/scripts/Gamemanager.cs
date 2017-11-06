using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour {

    private static Gamemanager _instance;
    public static Gamemanager Instance
    {
        get
        {
            return _instance;
        }
    }

    public int level = 1;
    public int food = 100;
    [HideInInspector]public List<cpu> cpulist = new List<cpu>();
    private bool sleepstep =true;
    private Text foodtext;
    private Text failtext;
    private p1 player;
    private Image day;
    private Text daytext;
    private mapmanager mapManager;
    public AudioClip die;
    [HideInInspector]public bool win = false;// arrive on exit or not
	// Use this for initialization
	void Awake () {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitGame()
    {
        //initialise game map
        mapManager = GetComponent<mapmanager>();
        mapManager.InitMap();
        //initialise UI
        foodtext = GameObject.Find("food").GetComponent<Text>();
        failtext = GameObject.Find("failed").GetComponent<Text>();
        failtext.enabled = false;
        updatefoodtext(0);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<p1>();
        day = GameObject.Find("day").GetComponent<Image>();
        daytext = GameObject.Find("daytext").GetComponent<Text>();
        daytext.text = "Day " + level;
        Invoke("hideblack", 2);
        //initialise parametre
        win = false;
        cpulist.Clear();
    }

    void updatefoodtext(int foodchange)
    {
        if (foodchange == 0)
        {
            foodtext.text = "Level:"+level+"\r\n"+"Food:" + food;
        }
        else
        {
            string str = "";
            if (foodchange < 0)
            {
                str = foodchange.ToString();
            }
            else
            {
                str = "+" + foodchange;
            }
            foodtext.text = "Level:" + level+"\r\n"+foodchange + " Food:" + food;
        }
    }
    public void Reducefood(int count)
    {
        food -= count;
        updatefoodtext(-count);
        if(food<=0)
        {
            failtext.enabled = true;
            audiomanager.Instance.RandomPlay(die);
            audiomanager.Instance.stopbgm();
        }
    }
    public void Addfood(int count)
    {
        food += count;
        updatefoodtext(count);
    }

    public void p1move()
    {
        if(sleepstep==true)
        {
            sleepstep = false;
        }
        else
        {
            foreach(var cpu in cpulist)
            {
                cpu.Move();
            }
            sleepstep = true;
        }
    }
    //check on exit
    public void on_exit()
    {
        if(player.targetpos.x==mapManager.cols-2&&player.targetpos.y==mapManager.rows-2)
        {
            win = true;
            //loading next scene
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    private void OnLevelWasLoaded(int scenelevel)
    {
        level++;//level plus
        InitGame();//initialise next level game
    }
    void hideblack()
    {
        day.gameObject.SetActive(false);
    }
}

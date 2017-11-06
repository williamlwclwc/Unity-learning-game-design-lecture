using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_control : MonoBehaviour {

    public GameObject[] enemy;
    public Vector3 spawnValue;
    public int as_count;
    public float spawnwait;//生成障碍物的间隔时间
    public float startwait;//开始游戏前的准备时间
    public float wavewait;//每一轮生成障碍间隔时间

    private int score;
    public Text scoretext;
    public Text gameover;
    public Text restart;
    private bool isgameover = false;
    private bool isrestart = false;

	// Use this for initialization
	void Start () {
        gameover.text = "";
        restart.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
        if (isgameover)
        {
            isrestart = true;
            restart.text = "Press R to try again";
        }
        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startwait);
        while (true)
        {
            for (int i = 0; i < as_count; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject obstacles = RandomPrefab(enemy);
                Instantiate(obstacles, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnwait);
            }
            yield return new WaitForSeconds(wavewait);
        }
    }

void UpdateScore()
    {
        scoretext.text = "Score: " + score;
    }

    public void addscore(int value)
    {
        if (isgameover == false)
        {
            score += value;
            UpdateScore();
        }
    }

    public void Gameover()
    {
        isgameover = true;
        gameover.text = "GameOver!!!";
    }

    private GameObject RandomPrefab(GameObject[] prefabs)
    {
        //put up random items
        int index = Random.Range(0, prefabs.Length);
        return prefabs[index];
    }
}

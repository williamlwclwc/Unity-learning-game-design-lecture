using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapmanager : MonoBehaviour {

    public GameObject[] outWallArray;
    public GameObject[] floorArray;
    public GameObject[] wallArray;
    public GameObject[] foodArray;
    public GameObject[] cpuArray;
    public GameObject exitPrefab;

    public int rows = 10;
    public int cols = 10;
    public int minCountWall=2;
    public int maxCountWall=8;

    private Transform mapHolder;
    private List<Vector2> positionlist = new List<Vector2>();

    private Gamemanager gameManager;

	// Use this for initialization
	void Awake () {
     
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    //Initialise the map
    public void InitMap()
    {
        gameManager = GetComponent<Gamemanager>();
        mapHolder = new GameObject("Map").transform;
        //Create outerwall&floor
        for(int x=0;x<cols;x++)
        {
            for(int y=0;y<rows;y++)
            {
                if(x==0||y==0||x==cols-1||y==rows-1)
                {
                    GameObject outwall = RandomPrefab(outWallArray);
                    GameObject go1=Instantiate(outwall,new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                    go1.transform.SetParent(mapHolder);
                }
                else
                {
                    GameObject floor = RandomPrefab(floorArray);
                    GameObject go1=Instantiate(floor, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                    go1.transform.SetParent(mapHolder);
                }
            }
        }
        //Create enemy(cpu),obstacles,food
        positionlist.Clear();
        for(int x=2;x<cols-2;x++)
        {
            for(int y=2;y<rows-2;y++)
            {
                positionlist.Add(new Vector2(x, y));
            }
        }
        //Creat obstacles 
        int wallcount = Random.Range(minCountWall, maxCountWall + 1);
        for(int i=0;i<wallcount;i++)
        {
            //obtain random position
            Vector2 pos=RandomPosition();
            //put up obstacles
            GameObject wallprefab = RandomPrefab(wallArray);
            GameObject go2 = Instantiate(wallprefab, pos, Quaternion.identity) as GameObject;
            go2.transform.SetParent(mapHolder);        
        }
        //Create cpu:num:level/2
        int enemyCount = gameManager.level / 2;
        for(int i=0;i<enemyCount;i++)
        {
            //obtain random position
            Vector2 pos = RandomPosition();
            //put up enemy
            GameObject enemy = RandomPrefab(cpuArray);
            GameObject go3 = Instantiate(enemy, pos, Quaternion.identity) as GameObject;
            go3.transform.SetParent(mapHolder);
        }
        //Create food:num:2-level*2
        int foodCount = Random.Range(2, gameManager.level * 2 + 1);
        for(int i=0;i<foodCount;i++)
        {
            //obtain random position
            Vector2 pos = RandomPosition();
            //put up food
            GameObject food = RandomPrefab(foodArray);
            GameObject go4 = Instantiate(food, pos, Quaternion.identity) as GameObject;
            go4.transform.SetParent(mapHolder);
        }
        //Create exit
        GameObject go5= Instantiate(exitPrefab, new Vector3(cols - 2, rows - 2), Quaternion.identity) as GameObject;
        go5.transform.SetParent(mapHolder);
    }
    private Vector2 RandomPosition()
    {
        //obtain random position
        int positionindex = Random.Range(0, positionlist.Count);
        Vector2 pos = positionlist[positionindex];
        positionlist.RemoveAt(positionindex);
        return pos;
    }
    private GameObject RandomPrefab(GameObject[] prefabs)
    {
        //put up random items
        int index = Random.Range(0, prefabs.Length);
        return prefabs[index];
    }
}

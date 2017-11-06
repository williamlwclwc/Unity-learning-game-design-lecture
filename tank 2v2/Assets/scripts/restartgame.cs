using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartgame : MonoBehaviour {

    public void OnStartGame(string scenename)
    {
        Application.LoadLevel(scenename);
    }

}

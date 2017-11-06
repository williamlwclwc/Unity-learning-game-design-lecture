using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menucontrol : MonoBehaviour {

    public void OnStartGame(string scenename)
    {
        Application.LoadLevel(scenename);
    }

}

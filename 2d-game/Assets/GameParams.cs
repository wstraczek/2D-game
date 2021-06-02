using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParams : MonoBehaviour {

    public int health = 3;
    public int level = 1;

    public static GameParams controller;

    void Awake(){

        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}

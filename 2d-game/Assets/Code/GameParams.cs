using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParams : MonoBehaviour {

    public int health = 3;
    public int level = 1;

    public static GameParams controller;

    void Awake(){

        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameController");

        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}

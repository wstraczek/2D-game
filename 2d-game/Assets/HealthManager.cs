using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour{

    GameParams livingParams;

    public GameObject[] hearts;
    private int health;
    private int level = 1;
    private int finalLevel = 2;
    public Text levelText;
    public GameObject endPanel;
    public GameObject life;
    public GameObject player;

    void Start(){
        livingParams = GameObject.Find("Params").GetComponent<GameParams>();
        loadLevel();
    }

    void Update(){
        ShowLevel();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Water" || coll.gameObject.tag == "Enemy"){
            health--;
            hearts[health].SetActive(false);
        }

        if (health == 0) {
            livingParams.health=3;
            livingParams.level=1;
            SceneManager.LoadScene("Level1");
        }

        if (coll.gameObject.tag == "Water") {
            livingParams.health=health;
            livingParams.level=level;
            SceneManager.LoadScene("Level"+level);
        }
        if (coll.gameObject.tag == "Finish") {
            if (level == finalLevel) {
                endPanel.SetActive(true);
                life.SetActive(false);
            } else {
                level++;
                livingParams.health=health;
                livingParams.level=level;
                SceneManager.LoadScene("Level"+level);

            }
        }
    }

    void loadLevel(){
        for (int i=2; i>=livingParams.health; i--){
            hearts[i].SetActive(false);
        }
        health = livingParams.health;
        level = livingParams.level;
    }

    public void ShowLevel(){
        string message = "Level: " + level;
        levelText.text = message;
    }

    public void onButtonRestartClicked(){
        livingParams.health=3;
        livingParams.level=1;
        SceneManager.LoadScene("Level1");
    }
}

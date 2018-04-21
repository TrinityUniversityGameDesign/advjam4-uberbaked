using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CentralGameController : MonoBehaviour {

    int score;
    public float timer;
    int goalScore;

    public Text timerText;

	// Use this for initialization
	void Start () {
        score = 0;
        timer = 60; // 1 minute
        goalScore = 20;
	}

    public void incrementScore(){
        score += 1;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        timerText.text = "Time Left: " + Mathf.FloorToInt(timer) + " seconds";

        if(timer < 0){
            //GameOver
            if(score >= goalScore){
                SceneManager.LoadScene("PlayerWin");
            } else {
                SceneManager.LoadScene("PlayerLose");
            }
        }
		
	}
}

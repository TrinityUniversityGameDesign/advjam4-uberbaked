using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSecondLevel : MonoBehaviour {
    public string buttonStart = "Start";
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(buttonStart))
        {
            SceneManager.LoadScene("SecondLevel");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinkingtitle : MonoBehaviour
{

    float counter = 10f;
    Text play;
    public float speed = 5;

    // Use this for initialization
    void Start()
    {
        play = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime * speed;
        Debug.Log(counter);
        if (counter <= 5)
        {
            play.enabled = false;
        }
        else if (counter >= 5)
        {
            play.enabled = true;
        }
        if (counter < 0f)
        {
            counter = 10f;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverContoller : MonoBehaviour {

    public GameObject gameController; 
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 1; i < 5; ++i)
        {
            if (Input.GetButtonDown("P" + i + "Collect") && collision.transform.Find("WeedContainer(Clone)") != null)
            {
                collision.transform.GetComponent<collection>().unsetCarry();
                GameObject weednug = collision.transform.Find("WeedContainer(Clone)").gameObject;
                GameObject.Destroy(weednug);
                if (weednug.GetComponent<NugDetails>().currentState == NugDetails.State.Rolled)
                {
                    gameController.GetComponent<CentralGameController>().incrementScore();
                }
            }
        }

    }
}

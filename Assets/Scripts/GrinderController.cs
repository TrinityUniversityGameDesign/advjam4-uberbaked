using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
                NugDetails weednug = collision.transform.Find("WeedContainer(Clone)").GetComponent<NugDetails>();
                if (weednug.GetComponent<NugDetails>().currentState == NugDetails.State.Nug) { 
                    weednug.currentState = NugDetails.State.Grinded;
                    weednug.updateModel();
                }
            }
        }

    }
}

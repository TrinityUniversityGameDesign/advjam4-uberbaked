using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour {

    public string buttonCollect;
    public string buttonRelease;
    private Rigidbody theRigidbody;
    private bool iscarrying;
	// Use this for initialization
	void Start () {
        theRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "collectme" && collision.transform.parent == null)
        {
            Debug.Log("there she goes");
            if (Input.GetButtonDown(buttonCollect) && !iscarrying)
            {
                Debug.Log("collected! :)");
                collision.transform.parent = transform;
                iscarrying = true;
            }
        }
        if (iscarrying && Input.GetButtonDown(buttonRelease))
        {
            // collision.transform.parent = null;
            transform.DetachChildren();
            iscarrying = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour {

    public string buttonCollect;
    public string buttonRelease;
    private Rigidbody theRigidbody;
    public bool iscarrying;
	// Use this for initialization
	void Start () {
        theRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (iscarrying && Input.GetButtonDown(buttonRelease))
        {
            transform.Find("WeedContainer(Clone)").GetComponent<Rigidbody>().useGravity = true;
            transform.Find("WeedContainer(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.Find("WeedContainer(Clone)").parent = null;
            // transform.DetachChildren();
            iscarrying = false;
        }
    }

    public void setCarry()
    {
        iscarrying = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Grinder" || collision.gameObject.tag == "Rolling" || collision.gameObject.tag == "Deliver" || collision.gameObject.tag == "Strain"){
            collision.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/HighlightShader");
        }

        if (collision.gameObject.tag == "collectme" && collision.transform.parent == null)
        {
            Debug.Log("there she goes");
            if (Input.GetButtonDown(buttonCollect) && !iscarrying)
            {
                Debug.Log("collected! :)");
                collision.transform.parent = transform;
                iscarrying = true;
                transform.Find("WeedContainer(Clone)").GetComponent<Rigidbody>().useGravity = false;
                transform.Find("WeedContainer(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        
    }
    private void OnCollisionExit(Collision collision){
       if(collision.gameObject.tag == "Grinder" || collision.gameObject.tag == "Rolling" || collision.gameObject.tag == "Deliver" || collision.gameObject.tag == "Strain"){
            collision.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        }
    }
}

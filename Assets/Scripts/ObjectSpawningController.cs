using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawningController : MonoBehaviour {

    GameObject nug;

    List<GameObject> items = new List<GameObject>();

	// Use this for initialization
	void Start () {
        
        nug = Resources.Load("Prefabs/WeedContainer") as GameObject;
        //item = Instantiate(item) as GameObject;
        //CreateNug(); //new Vector3(0,0,0));
        //CreateNug(); //new Vector3(0,1,0));
        //CreateNug();
	}

    public void CreateNug(Transform c) { // Vector3 loc)
        //Vector3 spawn = transform.parent.position;
        GameObject tempNug = Instantiate(nug, c);// new Vector3(spawn.x,spawn.y+1,spawn.z),Quaternion.identity) as GameObject; //,loc,Quaternion.Euler(0,0,0)) as GameObject;
       
        c.GetComponent<collection>().setCarry();
        //tempNug.GetComponent<Rigidbody>().AddForce(new Vector3(0,10,0);
        items.Add(tempNug);
    }

	// Update is called once per frame
	void Update () {
        /*if(Input.GetKeyDown(KeyCode.UpArrow)){
            item.GetComponent<NugDetails>().currentState = NugDetails.State.Grinded;
            item.GetComponent<NugDetails>().updateModel();
            Debug.Log("Changed Model");
            Debug.Log("outer: " + item.GetComponent<NugDetails>().currentState);
        }*/

        //CreateNug();
	}

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 1; i < 5; ++i)
        {
            if (Input.GetButtonDown("P" + i + "Collect") && !collision.transform.GetComponent<collection>().iscarrying)
            {
                CreateNug(collision.transform);
            }
        }
      
    }
}


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

    public void CreateNug() { // Vector3 loc){
        GameObject tempNug = Instantiate(nug) as GameObject; //,loc,Quaternion.Euler(0,0,0)) as GameObject;
        tempNug.GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0));
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

    private void OnCollisionEnter(Collision collision)
    {
        CreateNug();
    }
}

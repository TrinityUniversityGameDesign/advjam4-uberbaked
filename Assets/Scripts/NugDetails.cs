using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NugDetails : MonoBehaviour {

    GameObject currentStateModel;

    public enum State { Nug, Grinded, Rolled };
    public State currentState;

    GameObject nugState;
    GameObject grindedState;
    GameObject rolledState;

	// Use this for initialization
    void Start () {
        currentState = State.Nug;

        nugState = Instantiate(Resources.Load("Prefabs/IndicaNug")) as GameObject;
        nugState.transform.parent = transform;
        nugState.transform.localPosition = new Vector3(0, 0, 0);
        grindedState = Instantiate(Resources.Load("Prefabs/IndicaGrinded")) as GameObject;
        grindedState.transform.parent = transform;
        grindedState.transform.localPosition = new Vector3(0, 0, 0);
        rolledState = Instantiate(Resources.Load("Prefabs/IndicaRolled")) as GameObject;
        rolledState.transform.parent = transform;
        rolledState.transform.localPosition = new Vector3(0, 0, 0);

        //currentStateModel = Instantiate(nugState, transform.position, transform.rotation);
        //currentStateModel.transform.parent = transform;


        //nugState.SetActive(true);
	}

    public void updateModel(){
        if (currentState == State.Nug)
        {
            Debug.LogWarning("Changed model to nug");
            nugState.SetActive(true);
            grindedState.SetActive(false);
            rolledState.SetActive(false);
        }
        else if (currentState == State.Grinded)
        {
            Debug.LogWarning("Changed model to grinded");
            nugState.SetActive(false);
            grindedState.SetActive(true);
            rolledState.SetActive(false);
        }
        else if (currentState == State.Rolled)
        {
            Debug.LogWarning("Changed model to rolled");
            nugState.SetActive(false);
            grindedState.SetActive(false);
            rolledState.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No Active Model");
        }
    }
	
	// Update is called once per frame
	void Update () {
        updateModel();
        Debug.Log(currentState);
	}
}

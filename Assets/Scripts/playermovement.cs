using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float walkSpeed = 10f;
    private Rigidbody theRigidBody;



    public string axisHoriz;
    public string axisVert;

    // Use this for initialization
    void Start()
    {
        theRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        float inX = Input.GetAxis(axisHoriz);
        float inZ = Input.GetAxis(axisVert);
        theRigidBody.velocity = new Vector3(inX * walkSpeed, 0f, inZ * walkSpeed);
        GetComponent<Animator>().SetFloat("speed", theRigidBody.velocity.magnitude);
        transform.rotation = Quaternion.LookRotation(theRigidBody.velocity);
    }

}
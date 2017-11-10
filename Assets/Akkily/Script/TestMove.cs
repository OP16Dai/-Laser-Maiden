using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    //private Animator animator;

    float velZ = 2;
	// Use this for initialization
	void Start () {
       // animator = GetComponent<Animator>();
	}
	
    
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("up"))
        {
            
        }

        //velZ += 0.01f;
        transform.Translate(0, 0, velZ);

    }
}

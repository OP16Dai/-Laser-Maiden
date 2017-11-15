using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSide : MonoBehaviour {

    //回転速度(大きいほど早い)
    public float RotateSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //横に変更
        transform.Rotate(new Vector3(0, 0, RotateSpeed));
    }
}

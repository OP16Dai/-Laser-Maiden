using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //移動処理
        MoveTo();
	}

    //===================================================
    //移動処理
    //===================================================
    void MoveTo()
    {
        //1フレームごとに位置を変更
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);
    }
}

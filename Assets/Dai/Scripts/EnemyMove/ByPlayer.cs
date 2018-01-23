using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownByPlayer : MonoBehaviour {

    //動作開始フラグ
    bool StartMove = false;

    //プレイヤー一定距離に入る
    public float ComePlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //プレイヤーが一定距離内に入ったら動作開始
        if(transform.position.z - ComePlayer < GameObject.FindGameObjectWithTag("Player").transform.position.z && GameObject.FindGameObjectWithTag("Player").transform.position.z < transform.position.z)
        {
            StartMove = true;
        }
		
        //動作
        if(StartMove == true)
        {
      
        }
	}
}

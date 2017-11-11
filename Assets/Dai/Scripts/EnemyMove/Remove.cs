using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour {

    GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //プレイヤーを通り越したら削除
        RemoveRazer();
    }

    void RemoveRazer()
    {
        if (transform.position.z < (Player.transform.position.z - 5))
        {
            Destroy(gameObject);
        }
    }
}

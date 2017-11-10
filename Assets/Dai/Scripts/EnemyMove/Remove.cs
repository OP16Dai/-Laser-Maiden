using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //プレイヤーを通り越したら削除
        void RemoveRazer()
        {
            if (transform.position.z < (StartPosition.z - 5))
            {
                Destroy(gameObject);
            }
        }
    }
}

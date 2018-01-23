using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour {

    //移動上限
    public float TopLimit;
    //移動下限
    public float BottomLimit;

    //毎フレームの移動量
    public float MoveValue;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //上限位置に来たら向き変更
        if (transform.position.y >= TopLimit)
        {
            //移動量の向きが正なら負に
            if (MoveValue > 0)
            {
                MoveValue *= -1;
            }
        }
        //加減位置に来たら向き変更
        if (transform.position.y <= BottomLimit)
        {
            //移動量の向きが負なら正に
            if (MoveValue < 0)
            {
                MoveValue *= -1;
            }
        }

        //1フレームごとに位置を変更(Y軸)
        transform.position = new Vector3(transform.position.x, transform.position.y + MoveValue, transform.position.z);
    }
}

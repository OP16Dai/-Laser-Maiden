using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagonal : MonoBehaviour {

    //横軸
    public float MoveX = 0;

    //縦軸
    public float MoveY = 0;

    //奥行
    public float MoveZ = 0;

    //折り返しまでの時間
    public float BackTime;

    //時間経過
    int CountTime = 0;


    //============================================================
    // Use this for initialization
    //============================================================
    void Start () {
		
	}


    //============================================================
    // Update is called once per frame
    //============================================================
    void Update () {
        
        //移動処理
        MoveTo();

        //一定時間で向きを逆にする
        ComeBack();

        //時間経過
        CountTime++;
    }



    //============================================================
    //移動処理
    //============================================================
    void MoveTo()
    {
        //1フレームごとに位置を変更
        transform.position = new Vector3(transform.position.x + MoveX, transform.position.y + MoveY, transform.position.z + MoveZ);
    }

    //============================================================
    //向きを逆にする
    //============================================================
    void ComeBack()
    {
        if(CountTime >= BackTime * 60)
        {
            MoveX *= -1;
            MoveY *= -1;
            MoveZ *= -1;

            CountTime = 0;
        }
    }
}

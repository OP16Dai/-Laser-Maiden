using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThunderLeft : MonoBehaviour {

    //停止する横の壁
    public GameObject LeftWall;

    //何秒で壁に到達するか
    public float Speed = 1;

    //毎フレームの移動距離保管
    float m_moveX;

    // Use this for initialization
    void Start()
    {
        //毎フレームの移動距離計算
        m_moveX = ((LeftWall.transform.position.x - transform.position.x) / 60) / Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //壁に到達していなければ
        if (transform.position.x >= LeftWall.transform.position.x)
        {
            //1フレームごとに位置を変更
            transform.position = new Vector3(transform.position.x + m_moveX, transform.position.y, transform.position.z);
        }

        else
        {
            //壁に到達したら削除
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRazer : MonoBehaviour {

    //プレイヤ―の位置取得用
    public GameObject Player;


    //出現位置の設定(レーザー)
    public GameObject LaserStartPos;

    //移動速度
    public float Speed;

    //移動距離保管
    float x_move;
    float y_move;
    float z_move;



    // Use this for initialization
    void Start () {
        //速度設定
        SetSpeed();
        //初期位置の設定
        transform.position = new Vector3(
            LaserStartPos.transform.position.x,
            LaserStartPos.transform.position.y,
            LaserStartPos.transform.position.z);

    }

    // Update is called once per frame
    void Update () {
        //移動処理
        MoveTo();
        //レーザー削除処理
        RemoveRazer();
    }


    //速度設定
    void SetSpeed()
    {
        //速度と距離から毎フレームの移動距離を測定
        x_move = (0 - LaserStartPos.transform.position.x) / (Speed * 60);
        y_move = (0 - LaserStartPos.transform.position.y) / (Speed * 60);
        z_move = (0 - LaserStartPos.transform.position.z) / (Speed * 60);
    }

    //移動処理
    void MoveTo()
    {
        //1フレームごとに位置を変更
        transform.position = new Vector3(transform.position.x + x_move, transform.position.y + y_move, transform.position.z + z_move);
    }

    //プレイヤーを通り越したら削除
    void RemoveRazer()
    {
        if (transform.position.z < Player.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}

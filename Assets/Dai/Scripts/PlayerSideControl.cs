using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideControl : MonoBehaviour {

    //プレイヤー保管
    GameObject Player;
    //プレイヤー動作スクリプト保管
    PlayerMove PlayerMove;

    //右壁
    GameObject RightWallStopPos;
    //左壁
    GameObject LeftWallStopPos;

	// Use this for initialization
	void Start () {
        //プレイヤータグで取得
        Player = GameObject.FindGameObjectWithTag("Player");
        //プレイヤー動作スクリプト取得
        PlayerMove = Player.GetComponent<PlayerMove>();
        //右の停止位置を取得
        RightWallStopPos = GameObject.Find("RightWallStopPos");
        //左の停止位置を取得
        LeftWallStopPos = GameObject.Find("LeftWallStopPos");
    }
	
	// Update is called once per frame
	void Update () {
        //一定ラインより右に行くと
		if(Player.transform.position.x >= RightWallStopPos.transform.position.x)
        {
            PlayerMove.rightKey = false;   
        }
        //一定ラインより右に行くと
        if (Player.transform.position.x >= RightWallStopPos.transform.position.x)
        {
            PlayerMove.rightKey = false;
        }

        //一定ラインより左に行くと
        if (Player.transform.position.x <= LeftWallStopPos.transform.position.x)
        {
            PlayerMove.leftKey = false;   
        }
    }
}

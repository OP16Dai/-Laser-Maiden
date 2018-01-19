using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour {

    //======================================================================================
    //
    //  ステージクリア処理
    //      衝突したら
    //      ・プレイヤーの停止
    //      ・クリア表示
    //      ・タップで次ステージへ
    //      ・ステージの終了ならステージセレクトへ
    //
    //======================================================================================

    //プレイヤー保管
    public GameObject Player;
    //プレイヤーの制御スクリプト保管
    public PlayerMove PlayerMove;

    void OnTriggerEnter(Collider other)
    {
        //=============================================
        //衝突したのがプレイヤーの時
        //=============================================
        if (other.gameObject.CompareTag("Player"))
        {
            //プレイヤーの動きを停止
            //other.

            //プレイヤーを次の部屋へ移動
        }

        //=============================================
        //ステージクリアの表示
        //=============================================
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
}

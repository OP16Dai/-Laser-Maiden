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

    //タップ処理
    Touch touch = Input.GetTouch(0);

    //クリアフラグ
    bool Clear = false;
    //次への移動フラグ
    bool NextStage = false;

    void OnTriggerEnter(Collider other)
    {
        //=============================================
        //衝突したのがプレイヤーの時
        //=============================================
        if (other.gameObject.CompareTag("Player"))
        {
            //プレイヤーの動きを停止
            //other.

            //=============================================
            //ステージクリアの表示
            //=============================================
            if (this.Clear == false)
            {
                this.Clear = true;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //================================================
        //クリア表示処理
        //================================================
        if (this.Clear == true)
        {
            //クリア表示

            //ステージ移動可能に
            this.NextStage = true;
        }

        //===============================================
        //  クリア表示後の移動処理
        //===============================================
        if (this.NextStage == true)
        {    
            if (touch.phase == TouchPhase.Began)
            {
                //===============================
                // タッチ開始
                //===============================
                //タップされたらステージセレクトへ


            }
            else if (touch.phase == TouchPhase.Moved)
            {
                //===============================
                // タッチ移動
                //===============================

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                //===============================
                // タッチ終了
                //===============================

            }
        }
    }
}

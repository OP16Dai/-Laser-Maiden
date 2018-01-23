using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergence : MonoBehaviour {

    //プレイヤー保管
    GameObject Player;

    //ステージステータス管理オブジェクト保管
    GameObject Status;
    //レベル管理スクリプト保管
    LevelCount LevelCount;

    //現在のステージ
    int Stage;
    //現在のレベル
    int Level;

    //生成するプレファブ（敵）
    public GameObject[] Prefabs;
    //生成する位置
    Vector3 EnemyPos;

    //ステージ開始からの経過時間(フレーム数)
    int StageTime;
    //ステージが切り替わったら経過時間リセット
    bool ResetTime = false;


    //========================================================
    //
    //  関数はここから
    //
    //========================================================
    //========================================================
    // Use this for initialization
    //========================================================
    void Start () {
        //プレイヤー
        Player = GameObject.Find("Player");
        //ステージステータスオブジェクト保管
        Status = GameObject.Find("StageStatus");
        //レベル管理スクリプト保管
        LevelCount = Status.GetComponent<LevelCount>();
    }



    //========================================================
    // Update is called once per frame
    //========================================================
    void Update () {

        //現在のレベルを確認する
        NowLevel();

        //=====================================
        //レベル01の時
        //=====================================
        if (Level == 1)
        {
            //一定時間経過
            if (StageTime == 60)
            {
                /*
                 * @desc    プレファブの生成
                 * @param   生成するプレファブ
                 * @param   生成する位置
                 * @param   生成するときの向き
                 */
                //GameObject.Instantiate(Prefabs, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));

                //敵の出撃
                GameObject.Instantiate(Prefabs[1], new Vector3(-0.5f, 1.2f, 30), Prefabs[1].transform.rotation);
            }
            //一定時間経過
            if (StageTime == 120)
            {
                //敵の出撃
                GameObject.Instantiate(Prefabs[1], new Vector3(0.0f, 1.2f, 30), Prefabs[1].transform.rotation);
            }
            //一定時間経過
            if (StageTime == 180)
            {
                //敵の出撃
                GameObject.Instantiate(Prefabs[1], new Vector3(-1.5f, 1.2f, 30), Prefabs[1].transform.rotation);
            }
            //一定時間経過
            if (StageTime == 240)
            {
                //敵の出撃(ジャンプさせる)
                GameObject.Instantiate(Prefabs[0], new Vector3(-0.5f, 0.5f, 30), Prefabs[0].transform.rotation);
            }
            //一定時間経過
            if (StageTime == 300)
            {
                //敵の出撃（しゃがませる）
                GameObject.Instantiate(Prefabs[0], new Vector3(-0.5f, 2.0f, 30), Prefabs[0].transform.rotation);
            }


            //一定時間経過
            if (StageTime == 360)
            {
                //時間リセット
                ResetTime = false;
            }
        }
        //=====================================
        //レベル02の時
        //=====================================
        if (Level == 2)
        {
            //一定時間経過
            if (StageTime == 60)
            {
                //敵を出撃

            }
        }




        //ステージの切り替わりに一度経過時間リセット
        if (ResetTime == false)
        {
            StageTime = 0;
            ResetTime = true;
        }

        //経過時間(フレーム数)
        StageTime++;
    }


    //=========================================
    //現在のレベル確認
    //=========================================
    void NowLevel()
    {
        Level = LevelCount.Level;
    }

}

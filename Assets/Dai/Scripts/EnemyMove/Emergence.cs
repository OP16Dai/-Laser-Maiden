﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergence : MonoBehaviour {

    //ステージステータス管理オブジェクト保管
    GameObject Status;
    //レベル管理スクリプト保管
    LevelCount LevelCount;

    //現在のステージ
    int Stage;
    //現在のレベル
    int Level;

    //生成するプレファブ
    public GameObject[] Prefabs;

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
                GameObject.Instantiate(Prefabs[0], new Vector3(-0.5f, 1.2f, 30), Prefabs[0].transform.rotation);
            }
            //一定時間経過
            if (StageTime == 120)
            {
                //敵を出撃
                //敵の出撃
                GameObject.Instantiate(Prefabs[1], new Vector3(-0.5f, 1.2f, 30), Prefabs[1].transform.rotation);
            }
            //一定時間経過
            if (StageTime == 180)
            {
                //敵を出撃
                //敵の出撃
                GameObject.Instantiate(Prefabs[1], new Vector3(-0.5f, 1.2f, 30), Prefabs[2].transform.rotation);
            }
            //一定時間経過
            if (StageTime == 240)
            {
                //敵を出撃
                //敵の出撃
                GameObject.Instantiate(Prefabs[1], new Vector3(-0.5f, 1.2f, 30), Prefabs[3].transform.rotation);
            }


            //一定時間経過
            if (StageTime == 300)
            {
                //================
                //ステージ01終了
                //================

                //時間リセット
                ResetTime = false;
            }
        }
        //=====================================
        //レベル02の時
        //=====================================
        if (Level == 2)
        {
            //ステージの切り替わりに一度経過時間リセット
            if(ResetTime == false)
            {
                StageTime = 0;
                ResetTime = true;
            }

            //一定時間経過
            if (StageTime == 60)
            {
                //敵を出撃

            }
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

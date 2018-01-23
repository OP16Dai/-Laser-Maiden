using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {


    //プレイヤー保管
    GameObject Player;

    //生成するプレファブ（敵）
    public GameObject[] Prefabs;
    //生成する位置
    Vector3 EnemyPos;

    //ステージ開始からの経過時間(フレーム数)
    int StageTime = 0;


    // Use this for initialization
    void Start () {
        //プレイヤー
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {


        //=================================================
        //  敵の出撃
        //=================================================
        //一定時間経過
        if (StageTime == 30)
        {
            /*
             * @desc    プレファブの生成
             * @param   生成するプレファブ
             * @param   生成する位置
             * @param   生成するときの向き
             */
            //GameObject.Instantiate(Prefabs, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));

            //敵の出撃
            GameObject.Instantiate(Prefabs[0], new Vector3(0.0f, 0.0f, 20.0f), Prefabs[1].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 45)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[1], new Vector3(0.0f, 0.0f, 40.0f), Prefabs[1].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 60)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[2], new Vector3(0.0f, 0.0f, 60.0f), Prefabs[1].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 75)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[3], new Vector3(0.0f, 0.0f, 80.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 90)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[4], new Vector3(0.0f, 0.0f, 105.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 105)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[5], new Vector3(0.0f, 0.0f, 130.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 120)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[6], new Vector3(0.0f, 0.0f, 150.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 135)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[7], new Vector3(0.0f, 0.0f, 160.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 150)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[8], new Vector3(0.0f, 0.0f, 180.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 165)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[9], new Vector3(0.0f, 0.0f, 190.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 180)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[10], new Vector3(0.0f, 0.0f, 210.0f), Prefabs[0].transform.rotation);
        }
        //一定時間経過
        if (StageTime == 195)
        {
            //敵の出撃
            GameObject.Instantiate(Prefabs[11], new Vector3(0.0f, 0.0f, 2300.0f), Prefabs[0].transform.rotation);
        }



        //=================================================
        // 一定時間経過 時間リセット
        //=================================================
        if (StageTime == 1000)
        {
            //時間リセット
            StageTime = 0;
        }


        //=================================================
        // 経過時間(フレーム数)
        //=================================================
        StageTime++;
    }
}

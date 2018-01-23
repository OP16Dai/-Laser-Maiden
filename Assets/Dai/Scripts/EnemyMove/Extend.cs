using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {

    //毎フレーム伸ばす量(「-」のとき反対に伸ばす)
    public float extendX = 0;
    public float extendY = 0;
    public float extendZ = 0;

    //拡大量保管
    float scaleX;
    float scaleY;
    float scaleZ;


    //カウント
    int TimeCount;

    //===========================================================
    // Use this for initialization
    //===========================================================
    void Start () {
        //拡大量保管
        scaleX = extendX * 2; //元のサイズ的に２倍しておくくらいが拡大と移動量の数値が一致する
        scaleY = extendY;
        scaleZ = extendZ;

        if (extendX < 0) {
            scaleX *= -1;
        }
        if (extendY < 0)
        {
            scaleY *= -1;
        }
        if (extendZ < 0)
        {
            scaleZ *= -1;
        }
    }

    //===========================================================
    // Update is called once per frame
    //===========================================================
    void Update () {

        {
            //===========================================================================
            //拡大で両サイド伸ばして片方に位置をずらすことで一方向に伸びて行くようにする
            //===========================================================================
            //毎フレーム拡大
            transform.localScale = new Vector3(transform.localScale.x + scaleX, transform.localScale.y + scaleY, transform.localScale.z + scaleZ);
            //移動
            transform.position = new Vector3(transform.position.x + extendY, transform.position.y + extendX, transform.position.z + extendZ);

        }

        //カウント
        TimeCount++;
    }
}

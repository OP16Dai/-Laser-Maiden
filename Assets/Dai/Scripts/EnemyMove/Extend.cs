using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {

    //伸ばす量
    public float extendX = 0;
    public float extendY = 0;
    public float extendZ = 0;
    //速度
    public int Speed = 0;

    //カウント
    int TimeCount;

    //===========================================================
    // Use this for initialization
    //===========================================================
    void Start () {

    }

    //===========================================================
    // Update is called once per frame
    //===========================================================
    void Update () {
        if (TimeCount <= Speed * 60)
        {
            this.transform.localScale = new Vector3(transform.localScale.x + extendX / (Speed * 60), transform.localScale.y + extendY / (Speed * 60), transform.localScale.z + extendZ / (Speed * 60));
        }

        //カウント
        TimeCount++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

    //====================================================
    //  設定項目
    //====================================================
    //半径
    public float radius;

    //角度
    public float angle;

    //回転速度
    public float speed;

    //====================================================
    //  初期位置の保管
    //====================================================
    float m_startPosX;
    float m_startPosY;
    float m_startPosZ;


    // Use this for initialization
    void Start () {
        //初期位置の設定
        m_startPosX = this.transform.position.x;
        m_startPosY = this.transform.position.y;
        m_startPosZ = this.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        //====================================================
        //  回転処理
        //====================================================
        //位置の変更
        this.transform.position = new Vector3(radius * Mathf.Sin(angle) + m_startPosX, radius * Mathf.Cos(angle) + m_startPosY, m_startPosZ);
        //角度変更
        angle += speed;
	}
}

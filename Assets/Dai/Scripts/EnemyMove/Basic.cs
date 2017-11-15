using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour {
    
    //プレイヤー取得用
    GameObject Player;

    //１秒ごとの移動速度
    public float m_moveX;
    public float m_moveY;
    public float m_moveZ;

	// Use this for initialization
	void Start () {
        //===============================================
        //プレイヤーゲームオブジェクト指定
        //    (プレファブはスクリプトから指定=シーンに依存しないため)
        //===============================================
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //移動処理
        MoveTo();
    }

    //移動処理
    void MoveTo()
    {
        //1フレームごとに位置を変更
        transform.position = new Vector3(transform.position.x + m_moveX/60, transform.position.y + m_moveY/60, transform.position.z + m_moveZ/60);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour {
    
    //プレイヤー取得用
    GameObject Player;

    //何秒(60f/1s)でプレイヤーのところに行くか
    public float Speed =1f;

    //毎フレームの移動距離保管
    float m_moveZ;

	// Use this for initialization
	void Start () {
        //===============================================
        //プレイヤーゲームオブジェクト指定
        //    (プレファブはスクリプトから指定=シーンに依存しないため)
        //===============================================
        Player = GameObject.FindGameObjectWithTag("Player");
        //毎フレームの移動距離計算
        m_moveZ = ((Player.transform.position.z - transform.position.z) / 60) / Speed;
    }
	
	// Update is called once per frame
	void Update () {
        //移動処理
        MoveTo();
        //削除処理
        RemoveRazer();
    }

    //移動処理
    void MoveTo()
    {
        //1フレームごとに位置を変更
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + m_moveZ);
    }

    //プレイヤーを通り越したら削除
    void RemoveRazer()
    {
        if (transform.position.z < Player.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}

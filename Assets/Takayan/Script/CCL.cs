using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCL : MonoBehaviour {

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数

    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する Public 変数
    private Vector3 offset2;

    Animator anim;
                                    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        offset.z = transform.position.z - player.transform.position.z;

        offset2 = transform.position - player.transform.position;

        //プレイヤーのアニメーターを取得
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        
    }
	
	// Update is called once per frame
	void Update () {

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false)
        {

            //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
            transform.position = player.transform.position + offset;

        }
      


    }

    void LateUpdate()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == true)
        {

            //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
            transform.position = player.transform.position + offset;

           

        }
        else
        {
            offset2.y -= (player.transform.position.y);
            transform.position = player.transform.position + offset2;
            offset2.y += (player.transform.position.y);

  
        }
    }
}

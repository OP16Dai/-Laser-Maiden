using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    //Animatorコンポーネント
    Animator animator;

    //設定したフラグ名
    const string key_isJump = "isJump";


    void Start () {
        //自分に設定されているAnimatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();
    }
	
	void Update () {

        //上ボタンを押しているかどうか
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //WaitからJumpに遷移する
            this.animator.SetBool(key_isJump, true);
        }
        else
        {
            //RunからWaitに移動する
            this.animator.SetBool(key_isJump, false);
        }
    }
}

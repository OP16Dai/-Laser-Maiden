using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun : MonoBehaviour {

    //速度
    public float Speed;
    //右移動速度
    float RightMove = 0.5f;
    //左移動速度
    float LeftMove = 0.5f;

    //右
    bool Right = false;
    //左
    bool Left = false;


    //Animatorコンポーネント
    Animator animator;

    //設定したフラグ名
    const string key_isJump = "isJump";
    const string key_isSliding = "isSliding";
    const string key_isRun = "isRun";
    const string key_isIdle = "isIdle";

    // Use this for initialization
    void Start () {
        //自分に設定されているAnimatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //==========================================================================
        //
        //  操作処理
        //
        //==========================================================================
        //=========================
        //ジャンプ処理
        //=========================
        //押したとき
        if (Input.GetKeyDown(KeyCode.UpArrow) && animator.GetBool(key_isSliding) == false)
        {
            animator.SetBool(key_isIdle, false);
            animator.SetBool(key_isJump, true);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, false);
        }
        //放したとき
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool(key_isJump, false);
        }
        //=========================
        //スライディング処理
        //=========================
        //押したとき
        else if (Input.GetKeyDown(KeyCode.DownArrow) && animator.GetBool(key_isJump) == false)
        {
            animator.SetBool(key_isIdle, false);
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, true);
        }
        //放したとき
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool(key_isSliding, false);

        }

        //=========================
        //  右移動処理
        //=========================
        //押したとき
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.Right = true;
        }
        //放したとき
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.Right = false;
        }

        //=========================
        //  左移動処理
        //=========================
        //押したとき
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.Left = true;
        }
        //放したとき
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.Left = false;
        }

        //=================================================
        //  オートラン処理
        //=================================================
        MoveTo();

    }


    //===================================================
    //移動処理
    //===================================================
    void MoveTo()
    {
        //1フレームごとに位置を変更
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);

        //右移動
        if(this.Right == true)
        {
            //1フレームごとに位置を変更
            transform.position = new Vector3(transform.position.x + this.RightMove, transform.position.y, transform.position.z);
        }
        //左移動
        if (this.Left == true)
        {
            //1フレームごとに位置を変更
            transform.position = new Vector3(transform.position.x - this.LeftMove, transform.position.y, transform.position.z);
        }

    }
}

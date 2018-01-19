using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSample : MonoBehaviour
{



    [SerializeField]
    private float movement = 20f;
    [SerializeField]
    private float rotateSpeed = 20f;
    [SerializeField]
    private float GravityBoundary = 0.0f;
    float moveX = 0f, moveZ = 0f;
    Rigidbody rigidbody;

    //Animatorコンポーネント
    Animator animator;



    //設定したフラグ名
    const string key_isJump = "isJump";
    const string key_isSliding = "isSliding";
    const string key_isRun = "isRun";
    const string key_isIdle = "isIdle";

    //右キーを押せるかどうか
    public bool rightKey = true;
    [SerializeField]
    float RightBoundary = 0.0f;
    //左キーを押せるかどうか
    public bool leftKey = true;
    [SerializeField]
    float LeftBoundary = 0.0f;


    float TouchBeginPosition = 0.0f;
    Vector3 gyro = Vector3.zero;

    float gyroPosY = 1000.0f;

    string a = "none";

    void Start()
    {
        //自分に設定されているARigidbodyコンポーネントを取得する
        this.rigidbody = GetComponent<Rigidbody>();
        //自分に設定されているAnimatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();

        Input.gyro.enabled = true;


        gyroPosY = Input.gyro.attitude.y;



    }

    void OnGUI()
    {
        a = this.gyroPosY.ToString();


        // ラベルを表示する
        GUI.Label(new Rect(20, 20, 100, 50), a);
    }

    void Update()
    {

        

        //---------------------------------ここから入力処理---------------------------------


        if (this.transform.position.x > RightBoundary && this.rightKey != false)
        {
            this.rightKey = false;
        }
        else if (this.transform.position.x < RightBoundary && this.rightKey != true)
        {
            this.rightKey = true;
        }

        

        if (this.transform.position.x < LeftBoundary && this.leftKey != false)
        {
            this.leftKey = false;
        }
        else if (this.transform.position.x > LeftBoundary && this.leftKey != true)
        {
            this.leftKey = true;
        }

        //ここまで処理あり

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false && animator.GetCurrentAnimatorStateInfo(0).IsTag("Sliding") == false)
        {

            //画面がタッチされていたら
            if (Input.touchCount > 0)
            {

                //画面の中央より右側がタップされていて、rightkeyフラグがtrueなら
                if (Input.GetTouch(0).position.x > (Screen.currentResolution.width / 2) && this.rightKey == true)
                {
                    moveX = 1.0f;

                }//画面の中央より左側がタップされていて、leftKeyフラグがtrueなら
                else if (Input.GetTouch(0).position.x < (Screen.currentResolution.width / 2) && this.leftKey == true)
                {
                    moveX = -1.0f;

                }else
                {
                    moveX = 0.0f;
                }
            }
            else
            {
                moveX = 0.0f;
            }
           


            


            if ((Input.gyro.attitude.y) * 100 > 2)
            {
                moveZ = 1.0f;

            }
            else if ((Input.gyro.attitude.y) * 100 < -2)
            {
                moveZ = -1.0f;
            }
            else
            {
                moveZ = 0;
            }

            

            Vector3 direction = new Vector3(moveX, 0, moveZ);
            if (direction.magnitude > 0.01f)
            {
                Quaternion myQ = Quaternion.LookRotation(direction);
                float step = rotateSpeed * Time.deltaTime;

                this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);

            }
        }

        //---------------------------------ここからアニメーションの切り替え処理---------------------------------
        if (moveX != 0 || moveZ != 0)
        {
            animator.SetBool(key_isIdle, false);
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, true);
            animator.SetBool(key_isSliding, false);
           
        }
        else
        {
            //その他は待機
            animator.SetBool(key_isIdle, true);
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, false);
           
        }




        //---------------------------------ここから重力に関する処理---------------------------------
        if (this.transform.position.y < GravityBoundary)
        {
            rigidbody.useGravity = false;
        }
        else
        {
            rigidbody.useGravity = true;
        }


     


    }

    void FixedUpdate()
    {


    }

}

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
    float moveX = 0f, moveZ = 1.0f;
    Rigidbody rigidbody;

    //Animatorコンポーネント
    Animator animator;

    //効果音
    public AudioClip jump_clip;
    public AudioClip sliding_clip;
    public AudioSource SoundEffect_source;



    //設定したフラグ名
    const string key_isJump = "isJump";
    const string key_isSliding = "isSliding";
    const string key_isRun = "isRun";

    //右キーを押せるかどうか
    public bool rightKey = true;
    [SerializeField]
    float RightBoundary = 0.0f;
    //左キーを押せるかどうか
    public bool leftKey = true;
    [SerializeField]
    float LeftBoundary = 0.0f;

    //画面上で指が動いたかどうか
    bool moveFinger = false;

    float onTapPosition = 0.0f;
    float EndTapPosition = 0.0f;

    float TouchBeginPosition = 0.0f;

    string a = "none";

    void Start()
    {
        //自分に設定されているARigidbodyコンポーネントを取得する
        this.rigidbody = GetComponent<Rigidbody>();
        //自分に設定されているAnimatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();

      


    }

    void OnGUI()
    {
       


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



        //画面がタッチされていたら
        if(Input.touchCount > 0)
        {

            //タップした際の位置を保存
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                onTapPosition = Input.GetTouch(0).position.y;

                //タップを話した際の位置を保存
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                EndTapPosition = Input.GetTouch(0).position.y;
               
                //指を話した際にタップした場所との差分が一定の数値を超えていなければ
                if(!((onTapPosition - 150) > EndTapPosition) || !((onTapPosition + 150) < EndTapPosition))
                {
                    moveFinger = false;
                   
                }
            }

            //画面がタッチされ、一定距離を離れていたら
            if ((((onTapPosition - Input.GetTouch(0).position.y) > 20.0) || (Input.GetTouch(0).position.y - onTapPosition > 20.0)))
            {
                
                moveX = 0.0f;

                //画面上で指が動いたのでフラグにtrueを代入
                if(Input.GetTouch(0).phase != TouchPhase.Ended)
                    moveFinger = true;

            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false && animator.GetCurrentAnimatorStateInfo(0).IsTag("Sliding") == false
                && moveFinger == false)
            {

               
               

                //画面の中央より右側がタップされていて、rightkeyフラグがtrueなら
                if (Input.GetTouch(0).position.x > (Screen.currentResolution.width / 2) && this.rightKey == true)
                {
                    moveX = 1.0f;

                }//画面の中央より左側がタップされていて、leftKeyフラグがtrueなら
                else if (Input.GetTouch(0).position.x < (Screen.currentResolution.width / 2) && this.leftKey == true)
                {
                    moveX = -1.0f;

                }
                else
                {
                    moveX = 0.0f;
                }
            }
            else
            {
                moveX = 0.0f;
            }

            Vector3 direction = new Vector3(moveX, 0, moveZ);
            if (direction.magnitude > 0.01f)
            {
                Quaternion myQ = Quaternion.LookRotation(direction);
                float step = rotateSpeed * Time.deltaTime;

                this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);

            }

        }
        else
        {
            moveX = 0.0f;

            Vector3 direction = new Vector3(moveX, 0, moveZ);
            if (direction.magnitude > 0.01f)
            {
                Quaternion myQ = Quaternion.LookRotation(direction);
                float step = rotateSpeed * Time.deltaTime;

                this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);

            }
        }

       




        //---------------------------------ここからアニメーションの切り替え処理---------------------------------
        if (onTapPosition-150 > EndTapPosition && Input.GetTouch(0).phase == TouchPhase.Ended && 
            animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsTag("Sliding") == false)
        {
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, true);

            onTapPosition = 0;
            EndTapPosition = 0;

            //ジャンプが開始されたので、フラグにfalseを代入
            moveFinger = false;

            //エフェクト生成
            SoundEffect_source.PlayOneShot(sliding_clip);

        }
        else if (onTapPosition+150 < EndTapPosition && Input.GetTouch(0).phase == TouchPhase.Ended &&
            animator.GetCurrentAnimatorStateInfo(0).IsTag("Sliding") == false &&
            animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false)
        {
            animator.SetBool(key_isJump, true);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, false);

            onTapPosition = 0;
            EndTapPosition = 0;

            //ジャンプが開始されたので、フラグにfalseを代入
           moveFinger = false;

            //エフェクト再生
            SoundEffect_source.PlayOneShot(jump_clip);
        }
        else
        {
            //その他はrun
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, true);
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



        if (Input.GetKeyDown("space"))
        {
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, true);

         
        }


    }

    void FixedUpdate()
    {
        a = moveFinger.ToString();
        
    }

}

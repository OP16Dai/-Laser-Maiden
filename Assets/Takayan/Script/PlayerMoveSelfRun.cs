using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSelfRun : MonoBehaviour
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


    void Start()
    {
        //自分に設定されているARigidbodyコンポーネントを取得する
        this.rigidbody = GetComponent<Rigidbody>();
        //自分に設定されているAnimatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();

    }

    void Update()
    {



        //---------------------------------ここから入力処理---------------------------------




        //transform.position += transform.forward * 0.05f;



        if (Input.GetKey(KeyCode.J))
        {
            animator.SetBool(key_isIdle, false);
            animator.SetBool(key_isJump, true);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, false);
        }
        else if (Input.GetKey(KeyCode.G))
        {
            animator.SetBool(key_isIdle, false);
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, true);
        }
        else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
           || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {

            if((Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false && 
                this.transform.position.x > this.RightBoundary) || 
                    (Input.GetKey(KeyCode.LeftArrow) == true && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false &&
                this.transform.position.x < this.LeftBoundary))
            {
                animator.SetBool(key_isIdle, true);
                animator.SetBool(key_isJump, false);
                animator.SetBool(key_isRun, false);
                animator.SetBool(key_isSliding, false);
            }else
            {
                animator.SetBool(key_isIdle, false);
                animator.SetBool(key_isJump, false);
                animator.SetBool(key_isRun, true);
                animator.SetBool(key_isSliding, false);
            }
         
           
        }
        else
        {
            animator.SetBool(key_isIdle, true);
            animator.SetBool(key_isJump, false);
            animator.SetBool(key_isRun, false);
            animator.SetBool(key_isSliding, false);
        }




        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool(key_isJump, false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool(key_isSliding, true);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool(key_isSliding, false);
        }





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



        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false && animator.GetCurrentAnimatorStateInfo(0).IsTag("Sliding") == false)
        {

            if((this.rightKey == false && Input.GetAxis("Horizontal") > 0) || 
                (this.leftKey == false && Input.GetAxis("Horizontal") < 0))
            {
                moveX = 0;


            }
            else
            {
                moveX = Input.GetAxis("Horizontal") * Time.deltaTime * movement;
            }
            
            moveZ = Input.GetAxis("Vertical") * Time.deltaTime * movement;
            Vector3 direction = new Vector3(moveX, 0, moveZ);
            if (direction.magnitude > 0.01f)
            {
                Quaternion myQ = Quaternion.LookRotation(direction);
                float step = rotateSpeed * Time.deltaTime;

                this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);

            }
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
        //rb.velocity = new Vector3(moveX, 0, moveZ);
    }

}

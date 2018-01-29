using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {



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
    //Animationコンポーネント
    Animation animation;
    

    //設定したフラグ名
    const string key_isJump = "isJump";
    const string key_isSliding = "isSliding";
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

        
        if (this.transform.position.x > RightBoundary && this.rightKey != false)
        {
            this.rightKey = false;
        }else if(this.transform.position.x < RightBoundary && this.rightKey != true)
        {
            this.rightKey = true;
        }

        
        if(this.transform.position.x < LeftBoundary && this.leftKey != false)
        {
            this.leftKey = false;
        }else if(this.transform.position.x > LeftBoundary && this.leftKey != true)
        {
            this.leftKey = true;
        }
        


        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false && animator.GetCurrentAnimatorStateInfo(0).IsTag("Sliding") == false)
        {
            if(Input.GetKey(KeyCode.RightArrow) && rightKey == true)
            {
                moveX = Input.GetAxis("Horizontal") * Time.deltaTime * movement;
            }else if (Input.GetKey(KeyCode.LeftArrow) && leftKey == true)
            {
                moveX = Input.GetAxis("Horizontal") * Time.deltaTime * movement;
            }else
            {
                moveX = 0;
            }

            moveZ = 1 * Time.deltaTime * movement;
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



        //---------------------------------ここから入力処理---------------------------------




        //transform.position += transform.forward * 0.05f;


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool(key_isJump, true);

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

    }

    void FixedUpdate()
    {
        //rb.velocity = new Vector3(moveX, 0, moveZ);
    }

    /*

    //Animatorコンポーネント
    Animator animator;

    //設定したフラグ名
    const string key_isJump = "isJump";
    const string key_isRun = "isRun";
    //右キーを押したかどうか
    bool rightKey = false;
    //左キーを押したかどうか
    bool leftKey = false;


    void Start () {
        //自分に設定されているAnimatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();
    }
	
	void Update () {

       // Quaternion.LookRotation
        if (Input.GetKey("up"))
        {
            //transform.position += transform.forward * 0.05f;
            
            //animator.SetBool(key_isRun, true);
        }
        else
        {
            //animator.SetBool(key_isRun, false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
           
        }
        else
        {

        }

        
        if (Input.GetKey("right"))
        {
            
        }
        else
        {

        }


        if (Input.GetKey("left"))
        {
            
        }
        else
        {

        }
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool(key_isJump, true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool(key_isJump, false);
        }
        
    }

    */
}

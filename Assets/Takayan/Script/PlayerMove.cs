using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {



    [SerializeField]
    private float movement = 20f;
    [SerializeField]
    private float rotateSpeed = 20f;
    float moveX = 0f, moveZ = 0f;
    Rigidbody rb;

    //Animatorコンポーネント
    Animator animator;
    //Animationコンポーネント
    Animation animation;
    

    //設定したフラグ名
    const string key_isJump = "isJump";
    const string key_isRun = "isRun";
    //右キーを押したかどうか
    bool rightKey = false;
    //左キーを押したかどうか
    bool leftKey = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //自分に設定されているAnimatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();

    }

    void Update()
    {
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false)
        {
            moveX = Input.GetAxis("Horizontal") * Time.deltaTime * movement;
            moveZ = Input.GetAxis("Vertical") * Time.deltaTime * movement;
            Vector3 direction = new Vector3(moveX, 0, moveZ);
            if (direction.magnitude > 0.01f)
            {
                Quaternion myQ = Quaternion.LookRotation(direction);
                float step = rotateSpeed * Time.deltaTime;
                this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);
            }
        }





        //---------------------------------ここから入力処理---------------------------------





        if (Input.GetKey("up"))
        {
            //transform.position += transform.forward * 0.05f;

            animator.SetBool(key_isRun, true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {

            animator.SetBool(key_isRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            animator.SetBool(key_isRun, true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            animator.SetBool(key_isRun, true);
        }
        else
        {
            animator.SetBool(key_isRun, false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool(key_isJump, true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool(key_isJump, false);
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
<<<<<<< HEAD

    
         
=======
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool(key_isJump, false);
        }
        
>>>>>>> ddbbfb804b86e93067df6e259045cb137838c0e9
    }

    */
}

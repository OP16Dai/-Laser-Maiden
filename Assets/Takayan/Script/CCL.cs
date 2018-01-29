using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCL : MonoBehaviour {

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数

    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する Public 変数
    private Vector3 offset2;

    Animator anim;
    // Use this for initialization
    [SerializeField]
    public float x_aspect = 16.0f;
    [SerializeField]
    public float y_aspect = 9.0f;

    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = calcAspect(x_aspect, y_aspect);
        camera.rect = rect;
    }

    private Rect calcAspect(float width, float height)
    {
        float target_aspect = width / height;
        float window_aspect = (float)Screen.width / (float)Screen.height;
        float scale_height = window_aspect / target_aspect;
        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (1.0f > scale_height)
        {
            rect.x = 0;
            rect.y = (1.0f - scale_height) / 2.0f;
            rect.width = 1.0f;
            rect.height = scale_height;
        }
        else
        {
            float scale_width = 1.0f / scale_height;
            rect.x = (1.0f - scale_width) / 2.0f;
            rect.y = 0.0f;
            rect.width = scale_width;
            rect.height = 1.0f;
        }
        return rect;
    }

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        offset.z = transform.position.z - player.transform.position.z;

        offset2 = transform.position - player.transform.position;

        //プレイヤーのアニメーターを取得
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        Awake();


    }
	
	// Update is called once per frame
	void Update () {

        if(player != null)
        {
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump") == false)
            {


                //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
                transform.position = player.transform.position + offset;



            }
        }
      


    }

    void LateUpdate()
    {
        if(player != null)
        {
            //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
            transform.position = player.transform.position + offset;

        }
       

      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {

    //Planeクラスを入れる変数
    private Plane _plane;

    [SerializeField]
    private Vector3 normal;
    private Vector3 position;


    [SerializeField]
    private Vector3 samplePos;
    [SerializeField]
    private Vector3 ObjectPos;


    public void Create(Collider cd)
    {
        //Planeクラス作成
        _plane = new Plane();

        position = cd.transform.position;

        //ポイントと正規化された法線ベクトルの設定
        _plane.SetNormalAndPosition(normal, position);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.P) == true)
        {
            //Planeクラス作成
            _plane = new Plane();

            //ポイントと正規化された法線ベクトルの設定
            _plane.SetNormalAndPosition(normal, samplePos);
        }

        if (Input.GetKeyDown(KeyCode.I) == true)
        {
            bool a = this._plane.GetSide(ObjectPos);
            if(a == true)
            {
                Debug.Log("true");
            }else
            {
                Debug.Log("false");
            }
        }
	}


    //トリガーから抜けた際の処理
    void OnTriggerExit(Collider cd)
    {
        //this.Create(cd);
        Debug.Log("成功");
    }


}

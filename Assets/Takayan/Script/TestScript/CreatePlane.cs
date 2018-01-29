using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{

    //Planeクラスを入れる変数
    public Plane _plane;

    [SerializeField]
    private Vector3 normal;
    [SerializeField]
    private Vector3 position;

    // Use this for initialization
    void Start()
    {
        Create();
    }

    public void Create()
    {
        //Planeクラス作成
        _plane = new Plane();

       // position = this.transform.position;

        //正規化された法線ベクトルとポイントの設定
        _plane.SetNormalAndPosition(normal.normalized, position);
       

    }
    
    void update()
    {
        //プレイヤーに衝突したオブジェクトがEnemyタグならPlane作成
        
    }
}
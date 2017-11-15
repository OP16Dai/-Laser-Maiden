using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{

    //Planeクラスを入れる変数
    private Plane _plane;

   // [SerializeField]
    private Vector3 normal;
    private Vector3 position;

    // Use this for initialization
    void Start()
    {
    }

    public void Create()
    {
        //Planeクラス作成
        _plane = new Plane();

        position = this.transform.position;

        //ポイントと正規化された法線ベクトルの設定
        _plane.SetNormalAndPosition(normal, position);

    }
    
    void update()
    {
        //プレイヤーに衝突したオブジェクトがEnemyタグならPlane作成
        
    }
}
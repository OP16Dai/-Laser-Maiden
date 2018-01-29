
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このスクリプトが取り付けられたオブジェクトに
//メッシュレンダラーコンポーネントを取り付け
[RequireComponent(typeof(MeshRenderer))]

//このスクリプトが取り付けられたオブジェクトに
//メッシュフィルターコンポーネントを取り付け
[RequireComponent(typeof(MeshFilter))]

public class CreateMesh : MonoBehaviour
{

    //MeshFilterクラスはオブジェクトに取り付けられているメッシュフィルターコンポーネントのMeshにアクセスするクラス
    //そのMeshFilterクラスを入れる変数の宣言
    private MeshFilter _meshFilter;

    //Meshクラスはスクリプトからメッシュの作成や変更をできるようにするクラス
    //そのMeshクラスを入れる変数を宣言
    private Mesh _mesh;

    //ポリゴンの頂点を入れる変数
    public Vector3[] _vertices;

    void Start()
    {
        //クリエイト関数の呼び出し
        Create();
    }

    public void Create()
    {
        // 最小構成である三点ポリゴンを作る
        _mesh = new Mesh();

        //頂点座標配列を設定
        _vertices = new Vector3[]{
            new Vector3 ( 0.0f, 5.0f , 0.0f),
            new Vector3 ( 5.0f, 0.0f , 0.0f),
            new Vector3 (-5.0f, 0.0f , 0.0f),
        };

        //頂点を結ぶ順番配列
        //頂点を結ぶ順番(trianglesプロパティ)はメッシュを正しく表示させるためにとても重要な情報で、
        //Unityは時計回りに頂点を結んだ面が前面(法線の向き)になる
        var triangles = new int[]{
            0,1,2
        };

        //それぞれ代入
        _mesh.vertices = _vertices;
        _mesh.triangles = triangles;

        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = _mesh;


    }
}

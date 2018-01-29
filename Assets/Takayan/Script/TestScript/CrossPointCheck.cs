using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 交点を計算して確認するだけ
public class CrossPointCheck : MonoBehaviour
{

    public CreateMesh _createMesh; // CreateMeshクラス
    public CreatePlane _createPlane; // CreatePlaneクラス

    public Vector3 _pos1; // planeとmeshの交点その1
    public Vector3 _pos2; // planeとmeshの交点その2
 

    //-------
    // debug 頂点位置確認用
    public GameObject _prefabSphere;
    public List<GameObject> _posObjs;
    //------

    void Start()
    {
        _createMesh.Create();
        _createPlane.Create();
        Cut();
    }

    public void Cut()
    {
        var plane = _createPlane._plane; // CreatePlane側にgetter作ってあげてね

        var group1PosList = new List<Vector3>(); // グループ1頂点リスト
        var group2PosList = new List<Vector3>(); // グループ2頂点リスト

        CheckPlaneSide(plane, group1PosList, group2PosList); // 1.グループ分け

        CalcCrossPoint(plane, group1PosList, group2PosList); // 2.planeとの交点を求める

        DebugShowPos(); // デバッグ:頂点にsphere置いてグラフィカルに表示
    }

    // planeのどちらにあるかを計算して振り分ける
    private void CheckPlaneSide(Plane plane, List<Vector3> group1, List<Vector3> group2)
    {

        //plane.SetNormalAndPosition(new Vector3(0.0f,1.0f,0.0f).normalized,new Vector3(0.0f,2.5f,0.0f));

        var vertices = _createMesh._vertices;
        foreach (var v in vertices)
        {
            // どちらかのグループに振り分ける
            if (plane.GetSide(v))
            {
                group1.Add(v);
            }
            else
            {
                group2.Add(v);
            }

           // Debug.Log(plane.normal);
        }
    }

    // planeとmeshの交点を求める
    private void CalcCrossPoint(Plane plane, List<Vector3> group1, List<Vector3> group2)
    {

        float distance = 0;
        Vector3 basePos; // 計算する基準となる頂点
        Vector3 tmpPos1; // 基準点以外の頂点1
        Vector3 tmpPos2; // 基準点以外の頂点2


        Debug.Log(group1.Count);
        Debug.Log(group2.Count);


        // 少ない方からplaneに対して交差するpointを聞く
        if (group2.Count < group1.Count)
        {
          
            basePos = group2[0];
            tmpPos1 = group1[0];
            tmpPos2 = group1[1];
            
        }
        else
        {
            basePos = group1[0];
            tmpPos1 = group2[0];
            tmpPos2 = group2[1];
            
        }
        

        // 少ない所から多い片方の頂点に向かってrayを飛ばす。
        Ray ray1 = new Ray(basePos, (tmpPos1 - basePos).normalized);
        // planeと交差する距離を求める
        plane.Raycast(ray1, out distance);
        // ray1がその距離を進んだ位置を取得(ここが交点になる)
        _pos1 = ray1.GetPoint(distance);

        // 同じようにもう片方も計算
        Ray ray2 = new Ray(basePos, (tmpPos2 - basePos).normalized);
        plane.Raycast(ray2, out distance);
        _pos2 = ray2.GetPoint(distance);
    }

    // debug用の表示
    public void DebugShowPos()
    {
        if (_posObjs != null)
        {
            foreach (var o in _posObjs)
            {
                Destroy(o.gameObject);
            }
            _posObjs = null;
        }

        _posObjs = new List<GameObject>();

        var vertices = _createMesh._vertices;

        foreach (var v in vertices)
        {
            var go = Instantiate(_prefabSphere);
            go.transform.position = v;
            this.transform.SetParent(go.transform);
            _posObjs.Add(go);
        }

        var go1 = Instantiate(_prefabSphere);
        go1.transform.position = _pos1;
        this.transform.SetParent(go1.transform);
        _posObjs.Add(go1);

        var go2 = Instantiate(_prefabSphere);
        go2.transform.position = _pos2;
        this.transform.SetParent(go2.transform);
        _posObjs.Add(go2);
    }
}
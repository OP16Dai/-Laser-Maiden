using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    // 追従距離用のベクター
    Vector3 diff;

    // 追従ターゲットパラメータ
    public GameObject target;
    // 追従速度
    public float followSpeed;

    // Use this for initialization
    void Start()
    {
        // 追従距離計算
        diff = target.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        // 線形補間関数のスムージング
        // param1とparam2の距離によってparam1の速度を決める
        // 離れているほど速く、近いほど遅くなる
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - diff,
            Time.deltaTime * followSpeed
        );

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {

        // プレファブを同ポジションに生成
        GameObject SetObject = (GameObject)Instantiate(
            prefab,
            Vector3.zero,
            Quaternion.identity
        );

        // 一緒に削除されるように生成したレーザーオブジェクトを子に設定する
        SetObject.transform.SetParent(transform, false);
		
	}

    // ステージのレベルデザインのためにシーンにギズモを表示
    void OnDrawGizmos()
    {

        // ギズモの底辺が地面と同じ高さになるようにオフセット設定
        Vector3 offset = new Vector3(0, 0.5f, 0);

        // 球を表示
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + offset, 0.5f);

        // プレファブ名のアイコン表示
        if (prefab != null)
            Gizmos.DrawIcon(transform.position + offset, prefab.name, true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

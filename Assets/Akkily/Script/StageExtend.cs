using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExtend : MonoBehaviour {

    //=====================================
    // 定数はここから
    //=====================================
    // 1Tipのステージサイズ
    const int StageTipSize = 50;

    //======================================
    // 変数はここから
    //======================================
    // Tip番号
    int currentTipIndex;

   
 

    //===========================Public指定==============================

    // 指定キャラクター位置
    public Transform Character;
    // ステージチップprefabの配列
    public GameObject[] stageTips;
    // 自動生成を開始するインデックス
    public int startTipIndex;
    // 生成読み個数
    public int preInstantiate;
    // 生成済みステージチップを保持するリスト
    public List<GameObject> generatedStageList = new List<GameObject>();

    //====================================================================


    //====================================================================
    // 関数はここから
    //====================================================================
    
	// Use this for initialization
	void Start () {

        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
		
	}
	
	// Update is called once per frame
	void Update () {

        // キャラクターの位置から現在のステージチップのインデックスを計算
        int charaPositionIndex = (int)(Character.position.z / StageTipSize);

        // 次のステージチップに入ったらステージの更新処理を行う
        if (charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }

    }

    // 指定のIndexまでのステージチップを生成して、管理化に置く
    void UpdateStage(int toTipIndex)
    {
        // 指定インデックスを超えていなければ飛ばす
        if (toTipIndex <= currentTipIndex)
            return;

        // 指定のステージチップまで生成
        for(int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            // ステージ生成
            GameObject stageObject = generateStage(i);

            // 生成したステージチップを管理リストに追加
            generatedStageList.Add(stageObject);
        }

        // ステージ保持上限になるまで古いステージを削除
        while(generatedStageList.Count > preInstantiate + 2)
        {
            

            // 一番古いステージを取得
            GameObject oldStage = generatedStageList[0];
            // 管理リストから一番古いステージを取り去る
            generatedStageList.RemoveAt(0);
            // 一番古いステージを削除
            Destroy(oldStage);

            
        }

        // 指定番号の上書き
        currentTipIndex = toTipIndex;
    }

    // 指定のインデックス位置にステージオブジェクトをランダム生成
    GameObject generateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(13, 9, tipIndex * StageTipSize),
            Quaternion.identity
            );

        return stageObject;
    }
}

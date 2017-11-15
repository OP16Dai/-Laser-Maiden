using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController1 : MonoBehaviour {

    // 指定キャラクター
    public GameObject Character;
    // 位置表示ラベル
    public Text PosXLabel;
    public Text PosYLabel;
    public Text PosZLabel;

    public Text RoomPatternLabel;

    StageExtend m_StageExtend;

    // Use this for initialization
    /*
    void Start()
    {

    }
    */

    // Update is called once per frame
    void Update()
    {
        
        
        // Mathf.RoundToInt...小数点以下四捨五入＋整数化
        // Mathf.RoundToInt(floatPos - intPos * 10) で小数点１桁だけをとりだしている。
        int PosXPointOne = Mathf.RoundToInt((Mathf.Abs((float)Character.transform.position.x - (int)Character.transform.position.x)) * 10);
        int PosYPointOne = Mathf.RoundToInt((Mathf.Abs((float)Character.transform.position.y - (int)Character.transform.position.y)) * 10);
        int PosZPointOne = Mathf.RoundToInt((Mathf.Abs((float)Character.transform.position.z - (int)Character.transform.position.z)) * 10);
       
        

        if (Input.GetKey("z"))
        {
            // 小数点以下が 10 を超えていたら位が上がる
            // X
            if (PosXPointOne >= 10)
            {
                PosXPointOne = 0;
                // 位置が正なら +1 、 負なら -1
                if ((float)Character.transform.position.x > 0)
                {
                    PosXLabel.text = "PlayerPosY : " + ((int)Character.transform.position.x + 1) + "." + PosXPointOne;
                }
                else
                {
                    PosXLabel.text = "PlayerPosY : " + ((int)Character.transform.position.x - 1) + "." + PosXPointOne;
                }
            }
            else
            {
                PosXLabel.text = "PlayerPosX : " + (int)Character.transform.position.x + "." + PosXPointOne;
            }

            // Y
            if (PosYPointOne >= 10)
            {
                PosYPointOne = 0;
                if ((float)Character.transform.position.y > 0)
                {
                    PosYLabel.text = "PlayerPosY : " + ((int)Character.transform.position.y + 1) + "." + PosYPointOne;
                }
                else
                {
                    PosYLabel.text = "PlayerPosY : " + ((int)Character.transform.position.y - 1) + "." + PosYPointOne;
                }
            }
            else
            {
                PosYLabel.text = "PlayerPosY : " + (int)Character.transform.position.y + "." + PosYPointOne;
            }

            // Z
            if (PosZPointOne >= 10)
            {
                PosZPointOne = 0;
                if ((float)Character.transform.position.z > 0)
                {
                    PosZLabel.text = "PlayerPosZ : " + ((int)Character.transform.position.z + 1) + "." + PosZPointOne;
                }
                else
                {
                    PosZLabel.text = "PlayerPosZ : " + ((int)Character.transform.position.z - 1) + "." + PosZPointOne;
                }
            }
            else
            {
                PosZLabel.text = "PlayerPosZ : " + (int)Character.transform.position.z + "." + PosZPointOne;
            }

            // ルームパターンテキスト
            
            try
            {
                RoomPatternLabel.text = "Pattern : " + (string)m_StageExtend.generatedStageList[1].name ;
            }catch(System.Exception e) { RoomPatternLabel.text = "error"; }
            
        }
        else
        {
            PosXLabel.text = "";
            PosYLabel.text = "";
            PosZLabel.text = "";
            RoomPatternLabel.text = "";
        }
    }
}

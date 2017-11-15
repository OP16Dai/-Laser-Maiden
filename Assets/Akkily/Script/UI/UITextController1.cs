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
        // 10 を超えていたら位が上がるので０とする
        if (PosXPointOne >= 10) PosXPointOne = 0;
        if (PosYPointOne >= 10) PosYPointOne = 0;
        if (PosZPointOne >= 10) PosZPointOne = 0;

        if (Input.GetKey("z"))
        {
            PosXLabel.text = "PlayerPosX : " + (int)Character.transform.position.x + "." + PosXPointOne;
            PosYLabel.text = "PlayerPosY : " + (int)Character.transform.position.y + "." + PosYPointOne;
            PosZLabel.text = "PlayerPosZ : " + (int)Character.transform.position.z + "." + PosZPointOne;
        }
        else
        {
            PosXLabel.text = "";
            PosYLabel.text = "";
            PosZLabel.text = "";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Clear : MonoBehaviour
{

    //======================================================================================
    //
    //  ステージクリア処理
    //      
    //======================================================================================

    //プレイヤー保管
    GameObject Player;

    //音源
    public AudioClip clear_SE;
    //スピーカー
    public AudioSource clear_Source;


    // Use this for initialization
    void Start()
    {
        //プレイヤー
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが死んだら
        if(this.Player == null)
        {
            //ゲームオーバー
            Invoke("clear", 2.0f);


        }
    }

    
    private void OnTriggerEnter(Collider collision)
    {

            Invoke("clear", 1.0f);

            //ゲームクリア音を再生
            clear_Source.PlayOneShot(clear_SE);

    }

    void clear()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}

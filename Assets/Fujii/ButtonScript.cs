using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{

    [SerializeField]
    private string loadName;




    //生成したい音源を入れる変数
    public AudioClip onClick_SE;

    //オーディオソースを入れる変数
    //オーディオソースとはUnityで音を収音する為のもの
    public AudioSource AudioSE;

    public void OnClick()
    {

        //SEを鳴らす
        AudioSE.PlayOneShot(onClick_SE);

        Debug.Log("Button click");

        Invoke("CScene", 0.4f);

    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //ButtonA.enabled = true
    }

    void CScene()
    {
        // シーン遷移
        SceneManager.LoadScene(loadName);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    [SerializeField]
    private string loadName;

    public void OnClick()
    {
        SceneManager.LoadScene(loadName);
        //Debug.Log("Button click");
    }

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update (){
        
    }
}

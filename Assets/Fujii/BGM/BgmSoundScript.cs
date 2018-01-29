using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSoundScript : MonoBehaviour {

    //破棄したくないオブジェクト(BGM)
    public static BgmSoundScript BGM
    {
        get; private set;
    }

    // Use this for initialization
    void Start () {

        if (BGM == null)
        {
            BGM = this;
            DontDestroyOnLoad(BGM);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

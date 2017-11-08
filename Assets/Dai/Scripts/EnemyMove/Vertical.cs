using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //横に変更
        transform.Rotate(new Vector3(0, 0, -90));
    }

}

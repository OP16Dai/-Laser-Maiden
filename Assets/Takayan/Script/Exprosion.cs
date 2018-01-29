using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exprosion : MonoBehaviour {

    public GameObject obj;
    public GameObject Player;

    //爆発効果音
    public AudioClip exprosion_clip;
    public AudioSource SoundEffect_source;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetKeyDown("space"))
        {
            
            GameObject aa = Instantiate(obj);

            aa.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, this.transform.position.y+(0.5f), this.transform.position.z),this.transform.rotation);
        }
        
	}

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {


            SoundEffect_source.PlayOneShot(exprosion_clip);

            GameObject aa = Instantiate(obj);

            aa.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, this.transform.position.y + (0.5f), this.transform.position.z), this.transform.rotation);

            Destroy(Player);

            Player = null;
        }

       
    }
}

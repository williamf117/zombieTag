using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour {

    BoxCollider coll;
    Vector3 collSize;
    Vector3 rotation;
    bool horizontal;

    


	// Use this for initialization
	void Start () {
       coll=  gameObject.GetComponent<BoxCollider>();
        rotation = transform.eulerAngles;
        collSize = coll.size;

        if (Mathf.Abs(rotation.z) == 90)
        {
            horizontal = false;
        }
        else if(rotation.z==0)
        {
            horizontal = true;
        }


	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            //collision.gameObject.GetComponent<charicterControle>().lockangle(horizontal);
           // Debug.Log(horizontal);
        }
    }

}

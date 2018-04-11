using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControler : MonoBehaviour {
    int runspeed = 9;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * runspeed;
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name=="left")
        {
          
            transform.Rotate(0, 90 * Input.GetAxis("Rotate"), 0);
          

        }
        if (coll.gameObject.name=="Right")
        {
            transform.Rotate(0, 90 * Input.GetAxis("Rotate"), 0);
        }
    }
}

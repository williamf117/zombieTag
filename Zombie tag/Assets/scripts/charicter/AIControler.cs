using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControler : MonoBehaviour {
    int runspeed = 6;
    Timer starttimer;

	// Use this for initialization
	void Start () {
        starttimer = gameObject.AddComponent<Timer>();
        starttimer.Duration = 10;
        starttimer.Run();
	}
	
	// Update is called once per frame
	void Update () {
        lockangle();
	}
    void FixedUpdate()
    {
        if (starttimer.Finished)
        {
            transform.position += transform.forward * Time.deltaTime * runspeed;
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "turn")
        {
            transform.position = coll.gameObject.transform.position;
        }
        if (coll.gameObject.tag == "coin")
        {
            Physics.IgnoreCollision(coll.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        if (coll.gameObject.name=="righ")
        {
          
            transform.Rotate(0, -90 , 0);
            Destroy(coll.gameObject);
            

        }
        
        if (coll.gameObject.name=="Right")
        {
            transform.Rotate(0, 90 , 0);
            Destroy(coll.gameObject);
           
        }
     
    }


    public void lockangle()
    {

        {

            // Debug.Log(transform.rotation.y);
            if (transform.rotation.eulerAngles.y > 225 && transform.rotation.eulerAngles.y < 315)
            {
                transform.eulerAngles = new Vector3(0, 270, 0);
                //Debug.Log("Q");
            }
            else if (transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y < 135)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y < 225)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (transform.rotation.eulerAngles.y > -45 && transform.rotation.eulerAngles.y < 45)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            // Debug.Log(transform.rotation);



        }
    }
}

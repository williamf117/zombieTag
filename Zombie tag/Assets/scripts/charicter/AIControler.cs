using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIControler : MonoBehaviour {
    int runspeed = 8;
    Timer starttimer;
    //check if it can turn 
    bool turn = true;
    //center every turn
    Vector3 TurnCenter;
    Animator ani;

    // Use this for initialization
    void Start () {
        starttimer = gameObject.AddComponent<Timer>();
        starttimer.Duration = 4;
        starttimer.Run();

        //animation
        ani = GetComponent<Animator>();
        ani.SetInteger("runspeed", 6);

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
       
        if (coll.gameObject.tag == "coin")
        {
            Physics.IgnoreCollision(coll.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        if (coll.gameObject.tag=="left")
        {
          
            transform.Rotate(0,  - 90 , 0);
            TurnCenter = coll.gameObject.transform.position;
            Physics.IgnoreCollision(coll.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            Destroy(coll.gameObject);
            turn = false;

        }
        
        if (coll.gameObject.tag=="Right")
        {
            transform.Rotate(0,+ 90 , 0);
            Physics.IgnoreCollision(coll.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            //center on turn
            TurnCenter = coll.gameObject.transform.position;
            Destroy(coll.gameObject);
            

            turn = false;

        }
        if (coll.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("MainMenu");
        }

        if (coll.gameObject.tag == "floor")
        {
            turn = true;
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

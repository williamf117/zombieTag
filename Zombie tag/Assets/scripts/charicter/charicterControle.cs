using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charicterControle : MonoBehaviour
{
    //movement suport 
    Rigidbody rb;
    bool canRotate = true;
    Animator ani;
    int baseSpeed = 0;
    int maxSpeed = 7;
    int currentspeed;
    //timer
    Timer timer;
    float slowDowTimer = 2;
    bool grounded = true;
    Vector3 back;
    //touch suport
    Vector2 touchOrigin = -Vector2.one;

    //score 
    int score; 

    Direction playerFacing;

    // an enumeration to control direction 
    enum Direction
    {
        Right, Left, Back, Forwerd
    }

    // Use this for initialization
    void Start()
    {

        //get the rigid body
        rb = GetComponent<Rigidbody>();

        //get the animator
        ani = GetComponent<Animator>();
        ani.SetBool("walking", false);

        //get a timer component
        timer = gameObject.AddComponent<Timer>();
    }

    private void Update()
    {
        //lock angle to 90
        lockangle();

        if (transform.position.y < 1)
        {
            grounded = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump();
        }

        if (transform.rotation.y % 90 != 0)
        {
            transform.Rotate(0, 0, 0);
        }

#if UNITY_EDITOR
        // move fowered if the user is pushing space 
        if (Input.GetKeyDown(KeyCode.W))
        {

            ani.SetBool("walking", true);
            //increase speed based on button pushes
            if (currentspeed < maxSpeed)
            {
                currentspeed += 1;
            }
            timer.Duration = slowDowTimer;
            timer.Run();
        }
        //speed up and slow down based on taps one the fored key
        transform.position += transform.forward * Time.deltaTime * currentspeed;
        if (timer.Finished)
        {
            currentspeed = baseSpeed;
            ani.SetBool("walking", false);
        }





        if (Input.GetKeyDown(KeyCode.A))
        {
            back.y = transform.rotation.y;
            transform.Rotate(0, 90* Input.GetAxis("Rotate"), 0);
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            back.y = transform.rotation.y;
            transform.Rotate(0, 90 * Input.GetAxis("Rotate"), 0);

        }
        if (Input.GetAxis("Rotate") == 0)
        {
            canRotate = true;
        }




        // Update is called once per frame




        //Check if on android 
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        float dragDistance;
        dragDistance = Screen.height * 15 / 100;
        if (Input.touchCount>0)
        {
            ani.SetBool("walking", true);
            //increase speed based on button pushes
            if (currentspeed < maxSpeed)
            {
                currentspeed += 1;
            }
            timer.Duration = slowDowTimer;
            timer.Run();
        }

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }

           

        //dragDistance is 15% height of the screen
        else if (myTouch.phase == TouchPhase.Ended && myTouch.deltaPosition.x > dragDistance || myTouch.deltaPosition.y > dragDistance)
        {
            Vector2 toucheEnd = myTouch.position;

            float x = toucheEnd.x - touchOrigin.x;
            float y = toucheEnd.y - touchOrigin.y;
            touchOrigin.x = -1;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //rotate depending if user swipes left or right
                transform.Rotate(0, 90 * x / Mathf.Abs(x), 0);

            }
            else if (Mathf.Abs(y) > Mathf.Abs(x))
            {
                jump();
            }
        }
        }
        
   }
#endif
    }

  


    /// <summary>
    /// ump the charicter 
    /// </summary>
    void jump()
    {
        //if (grounded == true)
        {
            rb.AddForce(0, 500, 0);
            grounded = false;

        }
    }

    void OnCollisionEnter(Collision coll)
    {
        string tag = coll.gameObject.tag;
        switch (tag)
        {
            case "wall":
                turnback();
                break;
            case "floor":
                grounded = true;
                break;

        }
        if (coll.gameObject.tag == "coin")
        {
            Destroy(coll.gameObject);
            score++;

        }
        if (coll.gameObject.tag == "floor")
        {
           
        }

    }

    public void Move()
    {
        //increase speed based on button pushes
        if (currentspeed < maxSpeed)
        {
            currentspeed += 1;
        }
        timer.Duration = slowDowTimer;
        timer.Run();
    }
    public void turnback()
    {
        transform.Rotate(back);
    }

  public int Score
    {
        get
        {
            return score;
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
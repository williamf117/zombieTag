using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charicterControle : MonoBehaviour
{
    Rigidbody rb;
    bool canRotate = true;
    Animator ani;
    int baseSpeed = 0;
    int maxSpeed = 7;
    int currentspeed;
    Timer timer;
    float slowDowTimer = 2;
    bool grounded = true;

    //touch suport
    Vector2 touchOrigin = -Vector2.one;


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
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

        //jumoing



        if (Input.GetAxis("Rotate") != 0)
        {
            transform.Rotate(0, 180 * Time.deltaTime * Input.GetAxis("Rotate"), 0);
            canRotate = false;
        }
        if (Input.GetAxis("Rotate") == 0)
        {
            canRotate = true;
        }




        // Update is called once per frame




        //Check if on android 
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
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
            else if (myTouch.phase == TouchPhase.Ended )
            {
                Vector2 toucheEnd = myTouch.position;
                float x = toucheEnd.x - touchOrigin.x;
                float y = toucheEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if (Mathf.Abs(x)> Mathf.Abs(y))
                {
                    //rotate depending if user swipes left or right
                    transform.Rotate(0, 45 * x/Mathf.Abs(x), 0);
                    
                }
                else if (Mathf.Abs(y)>Mathf.Abs(x))
                {
                        jump();
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

        grounded = true;

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
}
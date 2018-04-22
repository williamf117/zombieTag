using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charicterControle : MonoBehaviour
{
    //movement suport 
    Rigidbody rb;
    bool canRotate = false;
    Animator ani;
    int baseSpeed = 0;
    int maxSpeed = 7;
    int currentspeed = 5;
    //timer
    Timer timer;
    float slowDowTimer = 2;
    bool grounded = true;
    Timer turn;
    Vector3 back;
    Vector3 TurnCenter;
    //touch suport
    Vector2 touchOrigin = -Vector2.one;

    //ai nodes 
    [SerializeField]
    GameObject left;
    [SerializeField]
    GameObject right;

    //score 
    int score;

    //sound support
    public AudioClip MusicClip;
    public AudioSource MusicSource;


    // Use this for initialization
    void Start()
    {
        //set soundmixer up
        MusicSource.clip = MusicClip;

        //get the rigid body
        rb = GetComponent<Rigidbody>();

        //get the animator
        ani = GetComponent<Animator>();
        ani.SetInteger("runspeed", 0);

        //get a timer component
        timer = gameObject.AddComponent<Timer>();
        turn = gameObject.AddComponent<Timer>();
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
        if (turn.Finished)
        {
            canRotate = false;
        }
        //#if UNITY_EDITOR || UNITY_STANDALONE
        // move fowered if the user is pushing space 
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move();
        }
        //speed up and slow down based on taps one the fored key
        transform.position += transform.forward * Time.deltaTime * currentspeed;
        if (timer.Finished)
        {
            currentspeed = baseSpeed;
            ani.SetInteger("runspeed", currentspeed);
        }




        if (canRotate)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {

                TurnLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                TurnRight();

            }
        }









        //Check if on android 
        //# UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
      
        if (Input.touchCount > 0)
        {
            ani.SetInteger("runspeed", currentspeed);
            //increase speed based on button pushes
            if (currentspeed < maxSpeed)
            {
                Move();
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
            else if (myTouch.phase == TouchPhase.Ended )
            {
                Vector2 toucheEnd = myTouch.position;

                float x = toucheEnd.x - touchOrigin.x;
                float y = toucheEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if (Mathf.Abs(x) > Mathf.Abs(y) && canRotate)
                {
                    //rotate depending if user swipes left or right


                    transform.position = TurnCenter;
                    if (x > 0)
                    {
                        TurnLeft();
                        Instantiate(left, transform.position, Quaternion.identity);
                    }
                    else if (x > 0)
                    {
                        TurnRight();
                        Instantiate(left, transform.position, Quaternion.identity);
                    }

                }
                else if (Mathf.Abs(y) > Mathf.Abs(x))
                {
                    jump();
                }
            }


        }
        //#endif
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
                currentspeed = 0;
                break;
            case "floor":
                grounded = true;
                break;
        }
        if (coll.gameObject.tag == "coin")
        {
            Destroy(coll.gameObject);
            score++;
            MusicSource.Play();
        }
        else if (coll.gameObject.tag == "turn")
        {
            Physics.IgnoreCollision(coll.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            canRotate = true;
            turn.Duration = .5f;
            turn.Run();
            TurnCenter = coll.gameObject.transform.position;
        }
        else if (coll.gameObject.tag == "Right" || coll.gameObject.tag == "left")
        {
            Physics.IgnoreCollision(coll.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
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
        ani.SetInteger("runspeed", currentspeed);
    }

    //alow game controler to see score 
    public int Score
    {
        get
        {
            return score;
        }
    }
    /// <summary>
    /// fixes the angle to 90 180 270 and 0
    /// </summary>
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


    void TurnRight()
    {
        back.y = transform.rotation.y;
        transform.Rotate(0, 90 * Input.GetAxis("Rotate"), 0);
        transform.position = TurnCenter;
        Instantiate(right, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
    }
    void TurnLeft()
    {
        back.y = transform.rotation.y;
        transform.Rotate(0, 90 * Input.GetAxis("Rotate"), 0);
        transform.position = TurnCenter;
        Instantiate(left, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// A basic script used to handle the UI timer and its functions
/// </summary>
public class TimerScript : MonoBehaviour
{
    //Timer varriables
    float UITimer = 45f;

    [SerializeField]
    Text playerTimer;

    // Use this for initialization
    void Start()
    {
        //Set the defualt text
        playerTimer.text = "Time Left: ";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Update Time on the UI
        playerTimer.text = "Time Left: " + UITimer.ToString("00");

        //Subtract 1 every second
        UITimer -= 1 * Time.deltaTime;

        if (UITimer <= 0)
        {
            LoadMainMenu();
        }
    }

    // Called when changing scene to the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

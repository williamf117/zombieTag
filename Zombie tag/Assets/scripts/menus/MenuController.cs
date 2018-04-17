using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// A basic class used to handle menu inputs
/// </summary>
public class MenuController : MonoBehaviour
{
    // Sound varriables for the button sfx
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Called 50 times per second
    public void FixedUpdate()
    {
        // Load the main menu if user presses 'esc'
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MusicSource.Play();
            LoadMainMenu();
        }
    }
    // Called when changing scene to the game
    public void LoadDemoLevel()
    {
        MusicSource.Play();
        SceneManager.LoadScene("City_scene_winter");
    }

    // Called when changing scene to the game
    public void LoadGPSMenu()
    {
        MusicSource.Play();
        SceneManager.LoadScene("GPSMenu");
    }

    // Called when changing scene to the control menu
    public void LoadControls()
    {
        MusicSource.Play();
        SceneManager.LoadScene("HelpMenu");
    }

    // Called when changing scene to the main menu
    public void LoadMainMenu()
    {
        MusicSource.Play();
        SceneManager.LoadScene("MainMenu");
    }
}

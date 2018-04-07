using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// A basic class used to handle menu inputs
/// </summary>
public class MenuController : MonoBehaviour
{
    // Called 50 times per second
    public void FixedUpdate()
    {
        // Load the main menu if user presses 'esc'
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
    // Called when changing scene to the game
    public void LoadDemoLevel()
    {
        SceneManager.LoadScene("City_scene_winter");
    }

    // Called when changing scene to the control menu
    public void LoadControls()
    {
        SceneManager.LoadScene("HelpMenu");
    }

    // Called when changing scene to the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

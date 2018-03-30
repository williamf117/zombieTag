using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// A class used to handle both the output of text, aswell as listen for input
/// </summary>
public class CoinPickUp : MonoBehaviour
{
    // Varriables for the coin counter
    public Text CoinText;
    float startTotal;

    // Set the timers time
    void Awake()
    {
        startTotal = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Cut the timer down to only show two decimal places
        string currentTotal = (startTotal).ToString();

        // Print out the current time to the screen
        CoinText.text = "Coins: " + currentTotal;
    }

    // Check for collisions with coins
    void OnCollisionEnter(Collision collision)
    {
        // Check to see if it was a coin
        if (collision.gameObject.tag == "coin")
        {
            // Increase the total score by one and destroy the coin
            startTotal += 1;
            Destroy(collision.gameObject);
        }
    }
}

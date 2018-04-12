using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// A basic script that will make UI text flash
/// </summary>
public class BlinkingText : MonoBehaviour
{
    // Varriables
    Text text;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        StartBlinking();
	}
	
    IEnumerator Blink ()
    {
        while (true)
        {
            switch(text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    yield return new WaitForSeconds(.5f);
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    yield return new WaitForSeconds(.5f);
                    break;
            }
        }
    }

	// Start blinkling
	void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    // Stop blinkling
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}

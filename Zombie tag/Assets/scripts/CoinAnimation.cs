using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class used to handle the movement and apperence of a coin
/// </summary>
public class CoinAnimation : MonoBehaviour
{
    // Move speed varriables
    float rotationSpeed = 100f;

	// Update is called 50 times per second
	void FixedUpdate ()
    {
        // Rotate the object
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
    }
}

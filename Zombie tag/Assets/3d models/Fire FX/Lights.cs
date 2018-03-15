using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lights : MonoBehaviour {
	private Light glow;
	public float time = 3.0f;
	private Boolean down = false;
	// Use this for initialization
	void Start () {
		glow = gameObject.GetComponent <Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (glow.intensity >= 0.0f && down == false) {
			glow.intensity += time * Time.deltaTime;
		}
		if (glow.intensity >= 7.0f && down == false) {
			down = true;
		}
		if (down) {
			glow.intensity -= time * Time.deltaTime;
			if (glow.intensity == 0.0f) {
				down = false;
				Destroy (gameObject);
			}
		}
	}
}

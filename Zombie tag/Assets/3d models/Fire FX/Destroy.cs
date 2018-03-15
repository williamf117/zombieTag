using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	public float time = 5.0f;

	void Start () {
		Destroy (gameObject,time);
	}

}

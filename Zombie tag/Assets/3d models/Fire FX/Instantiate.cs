using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour {

	public void create (GameObject obj){
		Instantiate (obj,transform.position,obj.transform.rotation);
	}
}

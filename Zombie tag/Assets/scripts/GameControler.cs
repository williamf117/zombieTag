using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {
    //score suport
    int score;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Text playerscore;
    int intScore;

    // Use this for initialization
    void Start () {
        //set score
        playerscore.text = "Coins: 0";
    }
	
	// Update is called once per frame
	void Update () {
        //change score and play sound 
        intScore = player.GetComponent<charicterControle>().Score;
        playerscore.text ="Coins: "+ intScore;
    }
}

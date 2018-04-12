using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayingMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (gameObject); //Dont stop the music
	}
}

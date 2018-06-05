using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayingMusic : MonoBehaviour {

    public static KeepPlayingMusic Instance = null;

    // Use this for initialization
    void Start () {

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject); //Dont stop the music
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

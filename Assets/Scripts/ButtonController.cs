using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	//Scene loading butttons
	public void HomeButton()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void RestartButton()
	{
		SceneManager.LoadScene ("MainGame");
	}

}

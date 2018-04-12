using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	private void OpenScene(string sceneToLoad)
	{
		SceneManager.LoadScene (sceneToLoad);
	}

	public void StartButton()
	{
		OpenScene ("MainGame");
	}

}

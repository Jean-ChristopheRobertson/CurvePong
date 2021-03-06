using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class MainMenuController : MonoBehaviour {


    public AchievementManager achMan;


    // Use this for initialization
    void Start () {

        achMan = FindObjectOfType(typeof(AchievementManager)) as AchievementManager;
	}

	private void OpenScene(string sceneToLoad)
	{
		SceneManager.LoadScene (sceneToLoad);
	}

	public void StartButton()
	{
		OpenScene ("MainGame");
        achMan.RegisterEvent(AchievementType.starts);
	}

    public void AcheivementsButton()
    {
        OpenScene("Acheivements");
    }

	public void ExitButton()
	{
		Application.Quit ();
	}

}

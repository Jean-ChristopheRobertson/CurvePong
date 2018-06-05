using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchTectController : MonoBehaviour {

    public AchievementManager achMan;


    // Use this for initialization
    void Start()
    {

        achMan = FindObjectOfType(typeof(AchievementManager)) as AchievementManager;


        foreach (KeyValuePair<string,string> entry in achMan.achievedText)
        {
            var achText = GameObject.Find (entry.Value).GetComponent<Text>();

            achText.text = entry.Key;

            if (entry.Value == "ach8")
            { 
                achText.color = new Color(0.5f, 0.5f, 0.5f, 1f);
                var hiddenAch = GameObject.Find("HiddenAch").GetComponent<SpriteRenderer>();
                hiddenAch.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

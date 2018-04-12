using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance = null; //Singleton, prevents duplicates

	//Sounds
	public AudioClip GoalSfx;
	public AudioClip LossSfx;
	public AudioClip WinSfx;
	public AudioClip HitPaddleSfx;
	public AudioClip HitWallSfx;

	private AudioSource soundEffectAudio;

	// Use this for initialization
	void Start () {

		// Using singleton to prevent dups
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) 
		{
			Destroy (gameObject);
		}

		AudioSource[] sources = GetComponents<AudioSource> ();

		foreach (AudioSource source in sources)
		{
			if (source.clip == null) {
				soundEffectAudio = source;
			}
		}
		
	}
	
	public void PlayOneShot(AudioClip clip) //Play clip once
	{
		soundEffectAudio.PlayOneShot (clip);
	}
}

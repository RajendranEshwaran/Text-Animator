using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


	public static AudioClip spawnSound, positiveSound, negativeSound;
	static AudioSource audiosource;
	// Use this for initialization
	void Start ()
	{

		spawnSound = Resources.Load<AudioClip> ("spawn");
		positiveSound = Resources.Load<AudioClip> ("positive");
		negativeSound = Resources.Load<AudioClip> ("negative");

		audiosource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public static void playSound (string clip)
	{
		switch (clip) {
		case "spawn":
			audiosource.PlayOneShot (spawnSound);
			break;
		case "positive":
			audiosource.PlayOneShot (positiveSound);
			break;
		case "negative":
			audiosource.PlayOneShot (negativeSound);
			break;

		}
	}
}

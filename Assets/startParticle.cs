using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startParticle : MonoBehaviour {

	public static ParticleSystem _starParticle;
	// Use this for initialization
	void Start () {


		_starParticle = GetComponent<ParticleSystem> ();

	}
	
	public static void starParticlePlay()
	{
		_starParticle.Play ();
	}

	public static void startParticleStop()
	{
		_starParticle.Stop ();
	}
}

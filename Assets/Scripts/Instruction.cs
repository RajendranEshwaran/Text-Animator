using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Instruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void loadGamePlay()
	{
		SceneManager.LoadScene ("GamePlay");
	}
}

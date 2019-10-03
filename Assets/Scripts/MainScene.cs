using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (loadScene ());
	}

	IEnumerator loadScene()
	{
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Instruction");
	}
}

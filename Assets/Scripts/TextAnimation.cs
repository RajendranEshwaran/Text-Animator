using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class TextAnimation : MonoBehaviour
{

	public Text timer_txt;
	public Text score_txt;
	public Text spawn_txt;
	private int score = 0;

	private Animator textAnimator;
	private bool isAnimatingSpawn = false;
	private bool isAnimatingUp = false;
	private bool isAnimatingDown = false;
	private bool isAnimatingStart = false;


	private int gameTime = 5;
	public int CountDownSeconds = 5;
	private float startTime = 0;
	private float restSeconds = 0;
	private int roundedRestSeconds = 0;
	private float displaySeconds = 0;
	private float displayMinutes = 0;
	private float Timeleft = 0;
	string timetext = "";


	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	private bool objectSpawn = false;
	private bool gameoverFlag = false;
	private int answerFlag = 0;
	private int userFlag = 0;
	private int swipeDetected = 0;

	private string path;
	private string jsonstring;
	//public SpawnObjectsList sol = new SpawnObjectsList();

	// Use this for initialization
	void Start ()
	{


		textAnimator = GetComponent<Animator> ();

		CountDownSeconds = gameTime;
		startTime = Time.time;

		spawn ();


	}



	// Update is called once per frame
	void Update ()
	{		
// TIMER START
		if (!gameoverFlag) {
			Timeleft = Time.time - startTime;
			restSeconds = CountDownSeconds - (Timeleft);
			roundedRestSeconds = Mathf.CeilToInt (restSeconds);
			displaySeconds = roundedRestSeconds % 60;
			displayMinutes = (roundedRestSeconds / 60) % 60;
			timetext = (displayMinutes.ToString () + ":");

			//Debug.Log (displaySeconds + "..." + roundedRestSeconds);
			if (displaySeconds > 1) {
				timetext = displaySeconds.ToString ();
			} else {
				timetext = displaySeconds.ToString ();
			} 

			timer_txt.text = timetext;

			if (roundedRestSeconds < 1) {
				userFlag = 0;
				if (swipeDetected == 0) {
					gameOver ();
				} else {
					ResetTimer ();
				}
			}
		}

// TIMER STOP
// SWIPE START

		if (Input.GetMouseButtonDown (0)) {
			//save began touch 2d point
			firstPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		}
		if (Input.GetMouseButtonUp (0)) {
			//save ended touch 2d point
			secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			//create vector from the two points
			currentSwipe = new Vector2 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			//normalize the 2d vector
			currentSwipe.Normalize ();
			//swipe upwards
			if (!objectSpawn) {
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					userFlag = 1;
					swipeDetected = 1;
					if (answerFlag == 1 && userFlag == 1) {
						userFlag = 0;
						score = score + 10;
						score_txt.text = score.ToString ();
						animationUp ();
					} else if (answerFlag == 2) {
						gameOver ();
					}
				}
				//swipe down
				if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					userFlag = 2;
					swipeDetected = 2;
					if (answerFlag == 2 && userFlag == 2) {
						userFlag = 0;
						score = score + 10;
						score_txt.text = score.ToString ();
						animationDown ();
					} else if (answerFlag == 1) {
						gameOver ();
					}
				}

			}
		}
	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds (1.0f);
		spawn ();

	}

	public void ResetTimer ()
	{
		startTime = Time.time;
		CountDownSeconds = gameTime;
	}

	public void gameOver ()
	{
		SceneManager.LoadScene ("GameOver");
	}

	IEnumerator spawnDelay ()
	{
		yield return new WaitForSeconds (0.5f);
		objectSpawn = false;
		SoundManager.playSound ("spawn");
	}

	IEnumerator positiveSoundDelay ()
	{
		yield return new WaitForSeconds (0.2f);
		SoundManager.playSound ("positive");
	}

		

	public void spawn ()
	{
		
		ResetTimer ();
		swipeDetected = 0;
		answerFlag = 0;
		objectSpawn = true;
		randomShuffle ();
		textAnimator.SetBool ("isAnimatingSpawn", true);
		textAnimator.SetBool ("isAnimatingDown", false);
		textAnimator.SetBool ("isAnimatingUp", false);
		isAnimatingSpawn = true;
		isAnimatingDown = false;
		isAnimatingUp = false;
		gameoverFlag = false;
		StartCoroutine (spawnDelay ());
		//Debug.Log("Spawn");

	}

	public void animationUp ()
	{
		textAnimator.SetBool ("isAnimatingUp", true);
		textAnimator.SetBool ("isAnimatingSpawn", false);
		textAnimator.SetBool ("isAnimatingDown", false);
		isAnimatingSpawn = false;
		isAnimatingDown = false;
		isAnimatingUp = true;
		objectSpawn = true;
		StartCoroutine (positiveSoundDelay ());
		StartCoroutine (Wait ());
	}

	public void animationDown ()
	{
		textAnimator.SetBool ("isAnimatingDown", true);
		textAnimator.SetBool ("isAnimatingSpawn", false);
		textAnimator.SetBool ("isAnimatingUp", false);
		isAnimatingSpawn = false;
		isAnimatingDown = true;
		isAnimatingUp = false;
		objectSpawn = true;
		StartCoroutine (positiveSoundDelay ());
		StartCoroutine (Wait ());
	}


	public void randomShuffle ()
	{

		int rnd = UnityEngine.Random.Range (0, 204);
		Questions qus = new Questions ();
		Checker chk = new Checker ();
		spawn_txt.text = qus.question [rnd];
		string answerTxt = chk.check [rnd];

		if (string.Compare (answerTxt, "up") == 0) {
			answerFlag = 1;
		} else {
			answerFlag = 2;
		}
		Debug.Log ("Answer Flag" + answerFlag);
	}

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TextAnimation : MonoBehaviour {

	public Text timer_txt;
	public Text score_txt;
	public Text spawn_txt;
	private int score = 0;

	private Animator textAnimator;
	private bool isAnimatingSpawn = false;
	private bool isAnimatingUp = false;
	private bool isAnimatingDown = false;
	private bool isAnimatingStart = false;


	private int gameTime=6;
	public int CountDownSeconds = 6; 
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
	private int  answerFlag = 0;
	private int userFlag = 0;

	// Use this for initialization
	void Start () {


		textAnimator = GetComponent<Animator> ();

		CountDownSeconds=gameTime;
		startTime = Time.time;
		Shuffle ();
		spawn ();
	}
	
	// Update is called once per frame
	void Update () {

// TIMER START
		if (!gameoverFlag) 
		{
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

			if (roundedRestSeconds < 1 ) {
				objectSpawn = false;
			}
			if (!objectSpawn) {
				//Shuffle ();
				//spawnObject ();
			}
		}
		if(roundedRestSeconds < 1)
		{
			userFlag = 0;
			ResetTimer ();
			//gameOver ();
		}
// TIMER STOP

// SWIPE START

		if(Input.GetMouseButtonDown(0))
		{
			//save began touch 2d point
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			//normalize the 2d vector
			currentSwipe.Normalize();

			//swipe upwards
			if(currentSwipe.y > 0 && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
			{
				userFlag = 1;
				if (answerFlag == 1 && userFlag == 1) {
					userFlag = 0;
					Debug.Log ("Swipe up");
					score = score + 10;
					score_txt.text = score.ToString ();

				} else {
					userFlag = 0;
					//gameOver ();
				}
			}
			//swipe down
			if(currentSwipe.y < 0 && currentSwipe.x > -0.5f  && currentSwipe.x < 0.5f)
			{

				userFlag = 2;
				if (answerFlag == 2 && userFlag == 2) {
					userFlag = 0;
					Debug.Log ("Swipe down");
					score = score + 10;
					score_txt.text = score.ToString ();

				} else {
					userFlag = 0;
					//gameOver ();
				}
			}

		}

// SWIPE STOP


		/*if (Input.GetKeyDown (KeyCode.Space) && !isAnimatingSpawn) {
			textAnimator.SetBool ("isAnimatingSpawn", true);
			textAnimator.SetBool ("isAnimatingDown", false);
			textAnimator.SetBool ("isAnimatingUp", false);
			isAnimatingSpawn = true;
			isAnimatingDown = false;
			isAnimatingUp = false;
			Debug.Log("Spawn");

		}
		else if (Input.GetKeyDown (KeyCode.A) && !isAnimatingDown) {
			textAnimator.SetBool ("isAnimatingDown", true);
			textAnimator.SetBool ("isAnimatingSpawn", false);
			textAnimator.SetBool ("isAnimatingUp", false);
			isAnimatingSpawn = false;
			isAnimatingDown = true;
			isAnimatingUp = false;
			Debug.Log("Down");


		}
		else if (Input.GetKeyDown (KeyCode.S) && !isAnimatingUp) {
			textAnimator.SetBool ("isAnimatingUp", true);
			textAnimator.SetBool ("isAnimatingSpawn", false);
			textAnimator.SetBool ("isAnimatingDown", false);
			isAnimatingSpawn = false;
			isAnimatingDown = false;
			isAnimatingUp = true;
			Debug.Log("Up");


		}*/

	}

	public void ResetTimer()
	{
		startTime=Time.time;
		CountDownSeconds = gameTime;
	}

	public void gameOver()
	{
		gameoverFlag = true;
		SceneManager.LoadScene ("GameOver");
		Debug.Log ("Game Over");
	}

	public void spawn()
	{
		textAnimator.SetBool ("isAnimatingSpawn", true);
		textAnimator.SetBool ("isAnimatingDown", false);
		textAnimator.SetBool ("isAnimatingUp", false);
		isAnimatingSpawn = true;
		isAnimatingDown = false;
		isAnimatingUp = false;
		Debug.Log("Spawn");
	}

	public void animationUp()
	{
		textAnimator.SetBool ("isAnimatingUp", true);
		textAnimator.SetBool ("isAnimatingSpawn", false);
		textAnimator.SetBool ("isAnimatingDown", false);
		isAnimatingSpawn = false;
		isAnimatingDown = false;
		isAnimatingUp = true;
		Debug.Log("Up");
	}

	public void animationDown()
	{
		textAnimator.SetBool ("isAnimatingDown", true);
		textAnimator.SetBool ("isAnimatingSpawn", false);
		textAnimator.SetBool ("isAnimatingUp", false);
		isAnimatingSpawn = false;
		isAnimatingDown = true;
		isAnimatingUp = false;
		Debug.Log("Down");
	}

	void Shuffle()
	{
		// int[] a = new int[] { 1,2,3,4,5,6,7,8,9,10 };
		string[] ans = new string[]{"down","down","down","down","up","up","down","up","down","up" };
		string[] qus = new string[] { "RAJAY", "GMS", "BOOKS", "CRICKET", "SPIDERMAN", "MONEY", "GAMES", "FLIGHT", "WEBSITE", "BALL" };

		int rnd = UnityEngine.Random.Range(0, 10);

		//spawnvalue_txt.text = qus [rnd];

		spawn_txt.text = qus [rnd];
		string answerTxt = ans [rnd];

		if (string.Compare(answerTxt,"up") == 0) {
			answerFlag = 1;
		} else {
			answerFlag = 2;
		}

	}

}

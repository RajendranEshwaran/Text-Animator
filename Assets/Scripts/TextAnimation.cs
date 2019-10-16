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
	public Image bg1;
	public Image bg2;
	private float speed = 0.5f;

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

	private float startPos = 750.0f;
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
//		if (bg1.transform.position.x < startPos) {
//			bg1.transform.position = Vector2 (Time.time * speed, 0);
//		}

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
						score = score + 5;
                        Unlock(score);
                        score_txt.text = score.ToString ();
						startParticle.starParticlePlay ();
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
						score = score + 5;
                        Unlock(score);
						startParticle.starParticlePlay();
						score_txt.text = score.ToString ();
						animationDown ();
					} else if (answerFlag == 1) {
						gameOver ();
					}
				}

			}
		}
	}

    public void postLeaderBoard(int score)
    {
        setting.AddScoreToLeaderboard(GPGSIds.leaderboard_flyupanddownboard, score);
    }
    public void Unlock(int score)
    {
        if(score == 20)
            setting.UnlockAchievement(GPGSIds.achievement_a_cool_reward);
        if (score == 50)
            setting.UnlockAchievement(GPGSIds.achievement_hungry_man);
        if (score == 75)
            setting.UnlockAchievement(GPGSIds.achievement_fabulous);
        if (score == 100)
            setting.UnlockAchievement(GPGSIds.achievement_marvelous);
        if (score == 125)
            setting.UnlockAchievement(GPGSIds.achievement_pretty_skilled);
        if (score == 150)
            setting.UnlockAchievement(GPGSIds.achievement_surprise);
        if (score == 175)
            setting.UnlockAchievement(GPGSIds.achievement_unlocked_facebook);
        if (score == 200)
            setting.UnlockAchievement(GPGSIds.achievement_unlock_twitter);
        if (score == 225)
            setting.UnlockAchievement(GPGSIds.achievement_magnificent_man);
        if (score == 250)
            setting.UnlockAchievement(GPGSIds.achievement_hero);
        if (score == 275)
            setting.UnlockAchievement(GPGSIds.achievement_specialist);
        if (score == 300)
            setting.UnlockAchievement(GPGSIds.achievement_alien);
        if (score == 325)
            setting.UnlockAchievement(GPGSIds.achievement_master_mind);
        if (score == 350)
            setting.UnlockAchievement(GPGSIds.achievement_computer_mind);
        if (score == 375)
            setting.UnlockAchievement(GPGSIds.achievement_dreamer);
        if (score == 400)
            setting.UnlockAchievement(GPGSIds.achievement_great_ability);
        if (score == 425)
            setting.UnlockAchievement(GPGSIds.achievement_brilliance);
        if (score == 450)
            setting.UnlockAchievement(GPGSIds.achievement_great_intelligent);
        if (score == 475)
            setting.UnlockAchievement(GPGSIds.achievement_talented);
        if (score == 500)
            setting.UnlockAchievement(GPGSIds.achievement_brainy);
        if (score == 525)
            setting.UnlockAchievement(GPGSIds.achievement_great_capacity);
        if (score == 550)
            setting.UnlockAchievement(GPGSIds.achievement_expert);
        if (score == 575)
            setting.UnlockAchievement(GPGSIds.achievement_faculty_mind);
        if (score == 600)
            setting.UnlockAchievement(GPGSIds.achievement_power);
        if (score == 625)
            setting.UnlockAchievement(GPGSIds.achievement_super_ability);
        if (score == 675)
            setting.UnlockAchievement(GPGSIds.achievement_einstein);
        if (score == 725)
            setting.UnlockAchievement(GPGSIds.achievement_master_giant);
        if (score == 750)
            setting.UnlockAchievement(GPGSIds.achievement_master);
        if (score == 775)
            setting.UnlockAchievement(GPGSIds.achievement_egg_head);
        if (score == 825)
            setting.UnlockAchievement(GPGSIds.achievement_bright_spark);
        if (score == 875)
            setting.UnlockAchievement(GPGSIds.achievement_encyclopedia);
        if (score == 925)
            setting.UnlockAchievement(GPGSIds.achievement_brainbox);
        if (score == 975)
            setting.UnlockAchievement(GPGSIds.achievement_super_man);

    }

    IEnumerator Wait ()
	{
		yield return new WaitForSeconds (0.5f);
		spawn ();

	}

	public void ResetTimer ()
	{
		startTime = Time.time;
		CountDownSeconds = gameTime;
	}

	public void gameOver ()
	{
        postLeaderBoard(score);

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
		string tempString = qus.question [rnd];

		if(tempString.Length > 10)
			tempString = tempString.Replace (" ", " " + System.Environment.NewLine);
		
		spawn_txt.text = tempString;
		string answerTxt = chk.check [rnd];

		if (string.Compare (answerTxt, "up") == 0) {
			answerFlag = 1;
		} else {
			answerFlag = 2;
		}
		Debug.Log ("Answer Flag" + answerFlag);
	}


   
}


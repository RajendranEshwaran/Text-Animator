using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames.BasicApi;
using GooglePlayGames;


public class setting : MonoBehaviour
{


    private void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
    }
    public void gotoSetting()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void gotoAchievement()
    {
        SceneManager.LoadScene("AchieveScene");
    }

    public void gotoInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void gotoCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void gotoRemoveAds()
    {
       // SceneManager.LoadScene("Instruction");
    }

    public void ShowAchievements()
    {
        ShowAchievementsUI();
    }
    public void ShowLeaderboards()
    {
        ShowLeaderboardsUI();
    }

    void SignIn()
    {
        Social.localUser.Authenticate(success => {
            if(success == true)
            {
                Debug.Log("Google Play Game Service Logged In Successfully!!");
            }
            else
            {
                Debug.Log("Unable to LogIn Google Play Game Service!!");
            }
        });
    }

    #region Achievements
    public static void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => {
            if (success == true)
            {
                Debug.Log("Acheivement UnLocked !!");
            }
            else
            {
                Debug.Log("Unable to Acheivement UnLocked");
            }
        });
    }

    public static void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public static void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }
    #endregion /Achievements

    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => {
            if (success == true)
            {
                Debug.Log("Score uploaded to Leaderboard !!");
            }
            else
            {
                Debug.Log("Score unable to upload Leaderboard!!");
            }
        });
    }

    public static void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion /Leaderboards
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setting : MonoBehaviour
{


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
}

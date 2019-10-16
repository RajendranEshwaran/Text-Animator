using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoBack : MonoBehaviour
{

    private Scene m_Scene;
    string sceneName;
    private void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }

    public void goBack()
    {
        SceneManager.LoadScene("MainScene");
        //switch(sceneName)
        //{
        //    case "CreditScene":
        //            SceneManager.LoadScene("MainScene");
        //        break;

        //    default:
        //        break;
        //}

    }

   
}

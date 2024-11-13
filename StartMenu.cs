using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports Unity scene manager
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //Public so it can be seen in Unity engine to be added to on click () part of button component
    public void StartGame()
    {
        //Loads the next scene (level 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Quits Game
    public void Quit()
    {
        Application.Quit();
    }
}

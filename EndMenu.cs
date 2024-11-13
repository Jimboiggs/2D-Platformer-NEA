using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    //Public so can be added to on click () in button component
    //Quits the game
    public void Quit()
    {
        Application.Quit();
    }

    //Public so can be added to on click () in button component
    //Restarts the game from level 1
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}

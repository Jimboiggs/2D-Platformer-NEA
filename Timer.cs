using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports Unity UI
using UnityEngine.UI;
//Imports SceneManagement from the Unity engine to allow us to check if game compelete screen is reached
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Allow timer texts to be added in Unity editor
    //Total game time is public becuase it is continued throughout levels
    public Text timerText;
    [SerializeField] private Text localTimeText;

    //Float values for time
    private float currentTime = 0f;
    private float localTime = 0f;

    private bool TimeEnd = false;
    private bool skipped = false;

    public Finish finishScript;
    public PauseMenu pauseMenu;


    private void Update()
    {
        //Only increments if level is not complete (checks using public variable from finish script)
        TimeEnd = Finish.levelCompleted;
        skipped = PauseMenu.levelSkipped;

        if (!TimeEnd && !skipped)
        {
            //Increments with change in time since last frame
            currentTime += Time.deltaTime;
            //Updates timer text to 2 decimal places
            timerText.text = currentTime.ToString("0.00");

            localTime += Time.deltaTime;
            localTimeText.text = localTime.ToString("0.00");

        }
        else
        {
            Debug.LogWarning("Reset");
            localTime = 0f;
            localTimeText.text = localTime.ToString("0.00");
        }

        if ((SceneManager.GetActiveScene().buildIndex) == (SceneManager.sceneCountInBuildSettings - 1))
        {
            currentTime = 0f;
            localTime = 0f;
        }

    }
}

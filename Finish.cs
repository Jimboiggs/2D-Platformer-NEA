using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports SceneManagement from the Unity engine to allow us to manage scenes
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    //Sets finish sound effect variable
    private AudioSource finishSound;
    //Creates boolean variable to dictate if level is complete
    public static bool levelCompleted = false;

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        GameObject timer = GameObject.FindGameObjectsWithTag("Timer")[0];
        timer.GetComponent<Timer>().finishScript = this;
    }

    //OnTriggerEnter2D is from Unity library
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player touches flag trigger and level is completed
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            //Plays finish sound
            finishSound.Play();
            //Makes level completed boolean true    
            levelCompleted = true;
            //Calls complete level after 2f seconds
            Invoke("CompleteLevel", 2f);
        }
    }


    //Function/void to call when level is completed
    private void CompleteLevel()
    {
        //Loads the level of the next build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

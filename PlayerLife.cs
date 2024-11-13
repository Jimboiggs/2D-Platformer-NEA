using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports Unity scene management
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //Gets animator and rigidbody 2D for player
    private Animator anim;
    private Rigidbody2D rb;

    //Allows death sound effect to be inserted in Unity editor
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        //Initiates animator and rigidbody 2D on start
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    //OnCollision2D method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detects trap
        if (collision.gameObject.CompareTag("Trap"))
        {
            //Runs death void/function
            Die();
        }
    }

    //Void/function runs when player dies
    public void Die()
    {
        //Stops movement of player
        rb.bodyType = RigidbodyType2D.Static;
        //Triggers death animation
        anim.SetTrigger("death");
        //Plays death sound effect
        deathSoundEffect.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

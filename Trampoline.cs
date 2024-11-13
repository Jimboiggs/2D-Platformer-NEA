using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    //Player Rigidbody2D assigned in Unity editor
    [SerializeField] private Rigidbody2D rb;
    //Jump force can be changed in Unity editor
    [SerializeField] private float jumpForce = 14f;
    //Jump sound audio source input in Unity editor
    [SerializeField] private AudioSource jumpSoundEffect;

    //Trigger box on top of trampoline
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks that game object in trigger box is the player
        if (collision.gameObject.name == "Player")
        {
            //Applies jump vector to Rigidbody2D of player
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //Plays jump sound effect
            jumpSoundEffect.Play();
        }
    }

}

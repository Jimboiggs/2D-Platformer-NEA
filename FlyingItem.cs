using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingItem : MonoBehaviour
{
    //Gets animator
    private Animator anim;
    //Gets Rigidbody2D
    private Rigidbody2D rb;
    //X and Y direction values
    private float dirX = 0f;
    private float dirY = 0f;
    //Movement speed can be changed in Unity editor
    [SerializeField] private float moveSpeed = 5f;
    //Boolean for whether flying item is active
    private bool active;

    private void Start()
    {
        //Gets components on start frame
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");
        rb = GetComponent<Rigidbody2D>();
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //On collision activates animation
        anim.SetTrigger("Active");
        //Sets active boolean to true
        active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //On end of collision deactivates animation *
        anim.SetTrigger("Idle");
        //Sets active boolean to false
        active = false;
    }

    private void Update()
    {
        //Calls movement subroutine every frame if flying item is active
        if (active)
        {
            Movement();
        }
    }

    //Allows X and Y movement of flying item
    //Not affected by gravity so can move freely
    private void Movement()
    {
        //Takes X and Y input
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        //Apply input to vector, proportional to moveSpeed
        rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
    }

}

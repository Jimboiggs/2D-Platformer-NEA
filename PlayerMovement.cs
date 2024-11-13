using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Gets rigidbody component so it does not have to be called every frame (private so only this script)
    private Rigidbody2D rb;
    //Stores character Animator component as variable anim
    private Animator anim;
    //DirX can now be called in seperate void to main update void, default value of 0f so is not undefined later
    private float dirX = 0f;
    //Assigns sprite renderer in engine to variable sprite
    private SpriteRenderer sprite;
    //Gives movement speed a variable
    //[SerializeField] allows value to be changed within the Unity editor
    //To reset to script values right click script in Unity editor and reset script
    //Public to be changed when mushroom item collected
    [SerializeField] public float playerMoveSpeed = 7f;
    //Gives jump force/height a variable
    [SerializeField] private float jumpForce = 14f;
    //Enum allows variable to hold own own set values, each has corresponding int value (hold mouse over it to see)
    private enum MovementState {Idle, Running, Jumping, Falling}
    //Gets BoxCollider2D of player
    private BoxCollider2D coll;
    //Calls layer of terrain used to check if player is on the ground
    [SerializeField] private LayerMask jumpableGround;
    //Allows jump sound file to be inserted in the editor
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        //Gets all variables on first frame / start
        rb = GetComponent< Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Horizontal Movement, includes joystick support, raw to stop character sliding after moving
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * playerMoveSpeed, rb.velocity.y);
        


        // Jump movement (Currently space bar change to contoller later (Unity input system))
        // && is "and" for if statement
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        //Running animation
        //If move forward running animation true
        if (dirX > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        //If move backwards running animation true and sprite flips to face left/backwards
        else if (dirX < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        //If not moving then idle animation plays instead
        else
        {
            state = MovementState.Idle;
        }

        //Sets animation when jumping (increasing height)
        //Checks for grounding in case on platform moving up
        if (rb.velocity.y > 0.1f && IsGrounded() == false)
        {
            state = MovementState.Jumping;
        }
        //Sets animation when falling (decreasing height)
        //Checks for grounding in case on platform moving down
        else if (rb.velocity.y < -0.1f && IsGrounded() == false)
        {
            state = MovementState.Falling;
        }

        //Sets animation state after loops which dictate animation state (using int value of our enum)
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //Box colliders
        //Creates box cast around player collider box to check if player is on the ground/ near walls
        //Used so player can only jump on ground, not above ground or by walls
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}

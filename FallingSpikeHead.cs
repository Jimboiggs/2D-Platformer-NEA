using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikeHead : MonoBehaviour
{

    //Rigidbody2D variable so spike head can be moved
    private Rigidbody2D rb;
    //Drop force can be changed from Unity editor
    [SerializeField] private float dropForce = -10f;

    private void Start()
    {
        //Gets Rigidbody2D component on start
        rb = GetComponent<Rigidbody2D>();
    }

    //Trigger box is under spike head (on ground)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks that the object in the trigger box is the player
        if (collision.gameObject.name == "Player")
        {
            //Drops spike head
            rb.velocity = new Vector2(rb.velocity.x, dropForce);
        }
        
    }

}

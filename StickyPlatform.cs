using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //Both use "Trigger" which is only for top box collider of moving platform

    //OnTriggerEnter2D part of Unity Library
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collided with player
        if (collision.gameObject.name == "Player")
        {
            //Sets player game object as a child of moving platform
            collision.gameObject.transform.SetParent(transform);
        }
    }
    //OnTriggerExit2D part of Unity library
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Sets player game object as not a child of moving platform
        collision.gameObject.transform.SetParent(null);
    }
}

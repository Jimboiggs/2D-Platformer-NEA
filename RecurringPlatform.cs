using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecurringPlatform : MonoBehaviour
{
    //Allows time to destroy to be changed from Unity engine
    [SerializeField] private float timeToDestroy = 1f;
    [SerializeField] private float timeToRespawn = 1f;

    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    //Detects collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Calls subroutine DisappearAfterDelay()
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        //Waits for 1 second
        yield return new WaitForSeconds(timeToDestroy);
        //Disables the platform
        //Dims platform sprite
        sprite.color = new Color(100, 100, 100, .5f);
        //Disables platform collider
        collider.enabled = false;
        //Waits for respawn for timeToRespawn seconds
        yield return new WaitForSeconds(timeToRespawn);
        //Reverts colour to normal
        sprite.color = Color.white;
        //Re-enables collider
        collider.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffPlatform : MonoBehaviour
{
    //Float to determine how long the game object stays in its current state before changing
    [SerializeField] private float timePerState = 1f;

    [SerializeField] private float initialDelay = 0f;

    //Creates sprite variable
    private SpriteRenderer sprite;
    //Creates box collier 2D variable
    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        //Sets sprite and boxcollider 2D variables to the components of the game object
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        //Start the pltform toggle subroutine
        StartCoroutine(TogglePlatform());
    }


    private IEnumerator TogglePlatform()
    {
        yield return new WaitForSeconds(initialDelay);
        while (true)
        {
            //Waits for time of the active state
            yield return new WaitForSeconds(timePerState);
            //Dims platform colour
            sprite.color = new Color(100, 100, 100, .5f);
            //Disables box collider 2D of game object
            collider.enabled = false;
            //Waits for time of the active state
            yield return new WaitForSeconds(timePerState);
            //Returns platform to normal colour
            sprite.color = Color.white;
            //Re-enables the box collider 2D
            collider.enabled = true;
        }

    }
}

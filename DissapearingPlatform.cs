using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingPlatform : MonoBehaviour
{
    //Allows time to destroy to be changed from Unity engine
    [SerializeField] private float timeToDestroy = 1f;

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
        //Destroys the platform
        Destroy(gameObject);
    }
}

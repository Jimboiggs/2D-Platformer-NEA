using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //Creates Animator variable
    private Animator anim;
    //Allows time for death animation to be input in Unity editor
    [SerializeField] private float animationTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Gets animator component on start
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Triggers death animation
            anim.SetTrigger("death");
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        //Waits for value held by animationTime variable (in seconds) so animation can play before death
        yield return new WaitForSeconds(animationTime);
        //Destroys the enemy
        Destroy(gameObject);
    }

}

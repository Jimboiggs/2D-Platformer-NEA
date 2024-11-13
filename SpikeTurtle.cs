using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTurtle : MonoBehaviour
{
    private Animator anim;
    //Boolean value showing active state
    private bool active = true;
    //5.05 seconds is time turtle is active before deactivating
    private float timeToWait = 5.05f;

    //Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Start the coroutine to toggle the active state
        StartCoroutine(ToggleState());
    }

    private IEnumerator ToggleState()
    {
        while (true)
        {
            //Wait for the end of current state (5.05 seconds)
            yield return new WaitForSeconds(timeToWait);
            //Toggle the active state with subroutine
            ToggleActive();
        }
    }

    private void ToggleActive()
    {
        //Invert boolean
        active = !active;
        //Change animation state
        anim.SetBool("active", active);

        // Change the tag and layer based on the new state
        if (active)
        {
            //Trap so can kill player
            gameObject.tag = "Trap";
            //Default layer as no need to be jumpable
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
        else
        {
            //Untagged so cannot hurt player
            gameObject.tag = "Untagged";
            //Ground so shell can be jumped on
            gameObject.layer = LayerMask.NameToLayer("Ground");
        }
    }
}

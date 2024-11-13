using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    //ADD COMMENTS

    [SerializeField] private float timeToMove = 1f;
    [SerializeField] private float swayMagnitude = 3f;
    private Rigidbody2D rb;
    private bool movingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Sway());
    }

    private IEnumerator Sway()
    {
        while (true)
        {
            if (movingUp)
            {
                rb.velocity = new Vector2(rb.velocity.x, swayMagnitude);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -swayMagnitude);
            }

            movingUp = !movingUp;

            yield return new WaitForSeconds(timeToMove);
        }
    }
}

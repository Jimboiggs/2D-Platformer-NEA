using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall : MonoBehaviour
{

    private Stack<float> stackX = new Stack<float>();
    private Stack<float> stackY = new Stack<float>();

    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private AudioSource spawnSet;
    [SerializeField] private AudioSource recall;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && IsGrounded())
        {
            spawnSet.Play();
            stackX.Push(transform.position.x);
            stackY.Push(transform.position.y);
            Debug.Log("Recall set");
        }

        if (Input.GetButtonDown("Fire2") && stackX.Count != 0 && stackY.Count != 0)
        {
            recall.Play();
            rb.MovePosition(new Vector3(stackX.Pop(), stackY.Pop(), transform.position.z));
        }
    }

    private bool IsGrounded()
    {
        //Box colliders
        //Creates box cast around player collider box to check if player is on the ground/ near walls
        //Used so player can only jump on ground, not above ground or by walls
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}

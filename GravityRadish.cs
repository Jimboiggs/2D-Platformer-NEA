using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRadish : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private float newGrav = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PLayer")
        {
            rb.gravityScale = newGrav;
            collectionSoundEffect.Play();
            Destroy(gameObject);
        }
    }

}

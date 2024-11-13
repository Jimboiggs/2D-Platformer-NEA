using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    [SerializeField] private AudioSource collectionSoundEffect;
    public float playerMoveSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMoveSpeed *= 2;
            collectionSoundEffect.Play();
            Destroy(gameObject);
        }
    }

}

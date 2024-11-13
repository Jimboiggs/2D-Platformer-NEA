using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Also imports Unity UI
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //Sets fruit counter to 0
    private int fruits = 0;
    //Allows fruit text overlay to be inserted in Unity editor
    [SerializeField] private Text FruitsText;
    //Allows collection sound effect to be inserted in Unity editor
    [SerializeField] private AudioSource collectionSoundEffect;

    //Imports OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Runs on collision with fruit
        if (collision.gameObject.CompareTag("Fruits"))
        {
            //Destroys fruit
            Destroy(collision.gameObject);
            //Increments fruits counter by 1
            fruits++;
            FruitsText.text = "Fruits: " + fruits;
            //Plays fruit collection sound effect
            collectionSoundEffect.Play();
        }
    }

}

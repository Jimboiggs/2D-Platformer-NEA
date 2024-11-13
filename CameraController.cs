using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;


    // Update is called once per frame
    private void LateUpdate()
    {
        //Each frame the camera is transformed to same position as player, keeping different Z value so the player can still be seen
        //transform.position = Vector3.Lerp(transform.position, new Vector3 (player.position.x, player.position.y, transform.position.z), .1f);
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}

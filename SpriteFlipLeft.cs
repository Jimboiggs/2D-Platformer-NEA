using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipLeft : MonoBehaviour
{
    // Reference to the WaypointFollower script
    [SerializeField] private WaypointFollower waypointFollower;

    // Update is called once per frame
    private void Update()
    {
        // Ensure waypointFollower is assigned
        if (waypointFollower == null)
        {
            Debug.LogError("WaypointFollower script is not assigned.");
            return;
        }

        // Get the current waypoint the object is moving towards
        Vector3 targetPosition = waypointFollower.Waypoints[waypointFollower.CurrentWaypointIndex].transform.position;
        // Determine the direction to the target
        Vector3 direction = targetPosition - transform.position;

        // Check if the object is moving left or right
        if (direction.x > 0)
        {
            // If moving right, flip the sprite to face left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x < 0)
        {
            // If moving left, flip the sprite to face right
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

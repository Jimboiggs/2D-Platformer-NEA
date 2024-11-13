using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Creates an array of waypoints to follow, serialized field so can be changed in the Unity editor
    [SerializeField] private GameObject[] waypoints;
    // Int variable for current waypoint number we are moving towards
    private int currentWaypointIndex = 0;

    // Float value for speed of moving game object (or units moved per second)
    [SerializeField] private float speed = 2f;

    // Public properties to access private fields
    public GameObject[] Waypoints => waypoints;
    public int CurrentWaypointIndex => currentWaypointIndex;

    // Update is called once per frame
    private void Update()
    {
        // Checks distance between moving game object and waypoint
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            // Increments currentWaypointIndex by 1 when very close to waypoint
            currentWaypointIndex++;
            // Reverts to 0 if end of array is reached
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // Moves the game object each frame
        // Time.deltaTime makes speed move from clock not frame rate
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}

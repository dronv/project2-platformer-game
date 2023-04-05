using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Useable for any gameObject moving between 2+ Waypoints
public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int current_waypoint = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[current_waypoint].transform.position, transform.position) < 1f)
        {
            current_waypoint += 1;
            if (current_waypoint >= waypoints.Length)
            {
                current_waypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[current_waypoint].transform.position,
            Time.deltaTime * speed);
    }
}

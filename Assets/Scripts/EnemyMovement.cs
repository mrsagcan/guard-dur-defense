using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private List<Waypoint> path;

    private void Start()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            print(waypoint.name);
        }
    }
}

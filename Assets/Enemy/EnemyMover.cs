using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>(); 
    void Start()
    {
        PrintNames();
    }

    private void PrintNames()
    {
        foreach (var waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

}

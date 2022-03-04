using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] private Waypoint startWaypoint;
    [SerializeField] private Waypoint endWaypoint;
    
    
    private void Start()
    {
        LoadBlocks();
        ColorBounds();
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
                continue;
            }
            grid.Add(gridPos,waypoint);
        }
        print("Loaded " + grid.Count + " blocks");
    }

    private void ColorBounds()
    {
        startWaypoint.SetTopColor(Color.gray);
        endWaypoint.SetTopColor(Color.black);
    }
}

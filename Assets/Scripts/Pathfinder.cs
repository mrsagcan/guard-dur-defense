using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] private Waypoint startWaypoint, endWaypoint;

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };
    
    private void Start()
    {
        LoadBlocks();
        ColorBounds();
        ExploreNeighbors();
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
            print("On the point " + gridPos);
        }
        print("Loaded " + grid.Count + " blocks");
    }

    private void ColorBounds()
    {
        startWaypoint.SetTopColor(Color.gray);
        endWaypoint.SetTopColor(Color.black);
    }

    private void ExploreNeighbors()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborGridPos = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[neighborGridPos].SetTopColor(Color.red);
            }
            catch {}
        }
    }
}

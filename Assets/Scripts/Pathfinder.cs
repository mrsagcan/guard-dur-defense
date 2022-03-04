using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Waypoint startWaypoint, endWaypoint;
    
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool isRunning = true;

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    
    private void Start()
    {
        LoadBlocks();
        ColorBounds();
        ExploreNeighbors();
        Pathfind();
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

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print("Searching: " + searchCenter);
            HaltIfEndFound(searchCenter);
        }
        print("Finished");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter.Equals(endWaypoint))
        {
            print("Reached the end.");
            isRunning = false;
        }
    }
}

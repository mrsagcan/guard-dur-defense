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


    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching: " + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
            searchCenter.isExplored = true;
        }
        print("Finished pathfinding.");
    }

    
    private void ExploreNeighbors(Waypoint from)
    {
        if(!isRunning) {return;}
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborGridPos = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbors(neighborGridPos);
            }
            catch {}
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborGridPos)
    {
        Waypoint neighbor = grid[neighborGridPos];
        if (!neighbor.isExplored)
        {
            neighbor.SetTopColor(Color.red);
            queue.Enqueue(neighbor);
            neighbor.isExplored = true;
            print("Queueing " + neighbor);
        }
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

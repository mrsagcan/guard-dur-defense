using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Waypoint startWaypoint, endWaypoint;

    private List<Waypoint> path = new List<Waypoint>();
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool isRunning = true;
    private Waypoint searchCenter;

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
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
            }
            else
            {
                grid.Add(gridPos,waypoint);
            }
        }
    }
    
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if(searchCenter == endWaypoint)
            isRunning = false;
    }
 
    private void ExploreNeighbors()
    {
        if(!isRunning) { return;}
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborGridPos = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(neighborGridPos))
                QueueNewNeighbors(neighborGridPos);
        }
    }
    
    private void QueueNewNeighbors(Vector2Int neighborGridPos) 
    {
        Waypoint neighbor = grid[neighborGridPos];
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            //do nothing for now leaving it that way because it breaks unity
        }
        else
        {
            
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        var previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }
}

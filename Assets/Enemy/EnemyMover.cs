using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] private float waitTime = 1f;
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }

}

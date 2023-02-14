using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}

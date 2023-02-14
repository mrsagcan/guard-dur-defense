using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;
    
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
        }
    }
}

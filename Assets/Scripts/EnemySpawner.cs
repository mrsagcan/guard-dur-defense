using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] private float secondsBetweenSpawns;
    [SerializeField] private EnemyMovement enemyPrefab;
    
    
    private void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    private IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab,transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}

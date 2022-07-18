using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float secondsBetweenSpawns;
    [SerializeField] private EnemyMovement enemyPrefab;
    
    
    private void Start()
    {
        RepeatedlySpawnEnemies();
    }

    private IEnumerator RepeatedlySpawnEnemies()
    {
        Instantiate(enemyPrefab);
        yield return new WaitForSeconds(secondsBetweenSpawns);
    }
}

using System;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private float attackRange;
    private ParticleSystem projectile;

    [SerializeField] private Transform targetEnemy;
    private void Start()
    {
        projectile = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            LookAtEnemy();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (var testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform firstEnemy, Transform secondEnemy)
    {
        float firstDistance = Vector3.Distance(transform.position, firstEnemy.position);
        float secondDistance = Vector3.Distance(transform.position, secondEnemy.position);
        if (secondDistance < firstDistance)
            return secondEnemy;
        return firstEnemy;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        Shoot(distanceToEnemy <= attackRange);
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }

    private void Shoot(bool state)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = state;
    }
}

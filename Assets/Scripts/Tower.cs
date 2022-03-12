using System;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private float attackRange;
    private ParticleSystem projectile;
    private void Start()
    {
        projectile = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
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

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        Shoot(distanceToEnemy <= attackRange);
    }

    private void LookAtEnemy()
    {
        transform.LookAt(targetEnemy);
    }

    private void Shoot(bool state)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = state;
    }
}

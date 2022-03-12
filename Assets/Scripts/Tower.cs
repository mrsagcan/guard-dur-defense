using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform targetEnemy;
    
    private void Update()
    {
        LookAtEnemy();
    }

    private void LookAtEnemy()
    {
        transform.LookAt(targetEnemy);
    }
}

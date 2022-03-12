using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    
    private void OnParticleCollision(GameObject other)
    {
        HitEnemy();
    }

    private void HitEnemy()
    {
        if (maxHitPoints == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            maxHitPoints--;
            print(maxHitPoints);
        }
    }
}

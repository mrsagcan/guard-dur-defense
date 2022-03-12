using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 10;
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        maxHitPoints--;
        if (maxHitPoints < 0)
        {
            Destroy(gameObject);
        }
    }
}

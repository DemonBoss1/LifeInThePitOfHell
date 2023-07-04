using UnityEngine;

namespace Script
{
    public class Compat : MonoBehaviour
    {
        public static void Attack(PlayerController attacker, Vector2 directionMovement, float radius, int damage)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attacker.Position + directionMovement, radius);
            foreach (var enemy in hitEnemies)
            {
                if (attacker.name == enemy.name) continue;
                HitPoints hp = enemy.GetComponent<HitPoints>();
                if (hp != null)
                {
                    hp.changeHP(-damage);
                }
            }
        }
    }
}

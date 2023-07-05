using UnityEngine;

namespace Script
{
    public class Compat : MonoBehaviour
    {
        public static void Attack(PlayerController attacker, Vector2 directionMovement, float radius, float damage)
        {
            Vector2 attackPos = attacker.Position;
            attackPos.y += 1f;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos + directionMovement, radius);
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

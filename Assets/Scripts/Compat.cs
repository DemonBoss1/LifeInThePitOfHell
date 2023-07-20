using UnityEngine;

public class Compat : MonoBehaviour
{
    public static void Attack(GameObject attacker, Vector2 directionMovement, float radius, float damage)
    {
        Vector2 attackPos = attacker.transform.position;
        attackPos.y += 1f;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos + directionMovement, radius);
        foreach (var enemy in hitEnemies)
        {
            if (attacker.name == enemy.name) continue;
            HitPoints hp = enemy.GetComponent<HitPoints>();
            if (hp != null)
            {
                hp.ChangeHp(-damage);
            }
        }
    }
}
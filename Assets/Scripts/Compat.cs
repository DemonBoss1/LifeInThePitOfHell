using UnityEngine;

public class Compat : MonoBehaviour
{
    public static void Attack(GameObject attacker, Vector2 directionMovement, float radius, float damage)
    {
        Vector2 attackPos = attacker.transform.position;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos, radius);
        float angle = 120f;
        foreach (var enemy in hitEnemies)
        {
            if (attacker.transform == enemy.transform) continue;
            HitPoints hp = enemy.GetComponent<HitPoints>();
            if (hp == null)
            {
                continue;
            }
            Vector2 deltaA = enemy.transform.position - attacker.transform.position;
        
            float tmpAngle = Mathf.Acos(Vector2.Dot(deltaA.normalized, directionMovement)) * Mathf.Rad2Deg;
            if (tmpAngle < angle * 0.5f) 
            {
                hp.ChangeHp(-damage);
            }
            

        }
    }
}
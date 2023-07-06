using UnityEngine;

namespace Script.System
{
    public class EnemyFactory : MonoBehaviour
    {
        public static void CreateEnemy(GameObject projectilePrefab, Vector2 pos, int level)
        {
            if (level > 0)
            {
                GameObject enemy = Instantiate(projectilePrefab, pos, Quaternion.identity);
                CharacterCharacteristics characteristics = enemy.GetComponent<CharacterCharacteristics>();
                characteristics.setLevel(level);
                EnemyCounter.count++;
            }
        }
    }
}

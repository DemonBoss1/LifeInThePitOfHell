using UnityEngine;

namespace Script.System
{
    public class EnemyFactory : MonoBehaviour
    {
        public static void CreateEnemy(GameObject projectilePrefab, Vector2 pos)
        {
            Instantiate(projectilePrefab, pos, Quaternion.identity);
        }
    }
}

using UnityEngine;

namespace Script.System
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] GameObject projectilePrefab;
        public static GameController gameController;
        private void Awake() {
            gameController = this;
        }
        public void SpawnEmpty()
        {
            Vector2 pos = new Vector2(-4, 2);
            EnemyFactory.CreateEnemy(projectilePrefab, pos);
        }
    }
}

using System;
using UnityEngine;

namespace Script.System
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] GameObject projectilePrefab;
        private EnemyFactory _factory;

        private void Awake()
        {
            _factory = this;
        }

        public void CreateEnemy(Vector2 pos, int level)
        {
            if (level > 0)
            {
                GameObject enemy = Instantiate(projectilePrefab, pos, Quaternion.identity);
                CharacterCharacteristics characteristics = enemy.GetComponent<CharacterCharacteristics>();
                characteristics.SetLevel(level);
            }
        }
    }
}

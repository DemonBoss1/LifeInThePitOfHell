using System;
using Script.UI;
using UnityEngine;

namespace Script.System
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] private Transform pos1, pos2, pos3;
        public static GameController gameController;
        private void Awake() {
            gameController = this;
        }

        private void Start()
        {
            SpawnEmpty();
        }

        public void SpawnEmpty()
        {
            if (UIDayControl.DayControl.Day % 3 == 1)
            {
                EnemyFactory.CreateEnemy(projectilePrefab, pos1.position, UIDayControl.DayControl.Day / 3 + 1);
                EnemyFactory.CreateEnemy(projectilePrefab, pos2.position, UIDayControl.DayControl.Day / 3);
                EnemyFactory.CreateEnemy(projectilePrefab, pos3.position, UIDayControl.DayControl.Day / 3);
            }
            else if (UIDayControl.DayControl.Day % 3 == 2)
            {
                EnemyFactory.CreateEnemy(projectilePrefab, pos1.position, UIDayControl.DayControl.Day / 3);
                EnemyFactory.CreateEnemy(projectilePrefab, pos2.position, UIDayControl.DayControl.Day / 3 + 1);
                EnemyFactory.CreateEnemy(projectilePrefab, pos3.position, UIDayControl.DayControl.Day / 3 + 1);
            }
            else if (UIDayControl.DayControl.Day % 3 == 0)
            {
                EnemyFactory.CreateEnemy(projectilePrefab, pos1.position, UIDayControl.DayControl.Day / 3);
                EnemyFactory.CreateEnemy(projectilePrefab, pos2.position, UIDayControl.DayControl.Day / 3);
                EnemyFactory.CreateEnemy(projectilePrefab, pos3.position, UIDayControl.DayControl.Day / 3);
            }
        }
    }
}

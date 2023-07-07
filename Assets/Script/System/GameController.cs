using System.Collections.Generic;
using Script.UI;
using UnityEngine;

namespace Script.System
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] private Transform pos1, pos2, pos3;
        public static GameController gameController;
        public List<GameObject> enemies = new List<GameObject>();
        [SerializeField] private GameObject wall;
        private void Awake() {
            gameController = this;
        }
        private void Start()
        {
            SpawnEnemy();
        }
        public void SpawnEnemy()
        {
            if (UIDayControl.DayControl.Day % 3 == 1)
            {
                EnemyFactory.CreateEnemy(projectilePrefab, pos1.position, CharacterCharacteristics.PlayerLevel);
                EnemyFactory.CreateEnemy(projectilePrefab, pos2.position, CharacterCharacteristics.PlayerLevel - 1);
                EnemyFactory.CreateEnemy(projectilePrefab, pos3.position, CharacterCharacteristics.PlayerLevel - 1);
            }
            else if (UIDayControl.DayControl.Day % 3 == 2)
            {
                EnemyFactory.CreateEnemy(projectilePrefab, pos1.position, CharacterCharacteristics.PlayerLevel - 1);
                EnemyFactory.CreateEnemy(projectilePrefab, pos2.position, CharacterCharacteristics.PlayerLevel);
                EnemyFactory.CreateEnemy(projectilePrefab, pos3.position, CharacterCharacteristics.PlayerLevel);
            }
            else if (UIDayControl.DayControl.Day % 3 == 0)
            {
                EnemyFactory.CreateEnemy(projectilePrefab, pos1.position, CharacterCharacteristics.PlayerLevel);
                EnemyFactory.CreateEnemy(projectilePrefab, pos2.position, CharacterCharacteristics.PlayerLevel);
                EnemyFactory.CreateEnemy(projectilePrefab, pos3.position, CharacterCharacteristics.PlayerLevel);
            }
            WallCheck();
        }

        public void WallCheck()
        {
            if (enemies.Count == 0)
            {
                wall.SetActive(false);
            }
            else
            {
                wall.SetActive(true);
            }
        }
    }
}

using System.Collections.Generic;
using Script.UI;
using UnityEngine;

namespace Script.System
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform pos1, pos2, pos3;
        public static GameController gameController;
        public static int EnemyCounter = 0;
        [SerializeField] private GameObject wall;
        [SerializeField] private EnemyFactory _factory;
        private void Awake() {
            gameController = this;
        }
        private void Start()
        {
            SpawnEnemies();
        }
        public void SpawnEnemies()
        {
            bool levelNull = UIDayControl.DayControl.Day / 3 == 0;
            print(levelNull);

            if (UIDayControl.DayControl.Day % 3 == 1)
            {
                SpawnEnemy(pos1.position, CharacterCharacteristics.PlayerLevel);
                if (!levelNull)
                {
                    SpawnEnemy(pos2.position, CharacterCharacteristics.PlayerLevel - 1);
                    SpawnEnemy(pos3.position, CharacterCharacteristics.PlayerLevel - 1);
                }
            }
            else if (UIDayControl.DayControl.Day % 3 == 2)
            {
                if (!levelNull)
                    SpawnEnemy(pos1.position, CharacterCharacteristics.PlayerLevel - 1);
                SpawnEnemy(pos2.position, CharacterCharacteristics.PlayerLevel);
                SpawnEnemy(pos3.position, CharacterCharacteristics.PlayerLevel);
            }
            else if (UIDayControl.DayControl.Day % 3 == 0)
            {
                SpawnEnemy(pos1.position, CharacterCharacteristics.PlayerLevel);
                SpawnEnemy(pos2.position, CharacterCharacteristics.PlayerLevel);
                SpawnEnemy(pos3.position, CharacterCharacteristics.PlayerLevel);
            }
            WallCheck();
        }

        public void SpawnEnemy(Vector2 pos, int level)
        {
            _factory.CreateEnemy(pos, level);
            EnemyCounter++;
        }


        public void WallCheck()
        {
            print(EnemyCounter);
            if (EnemyCounter == 0)
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

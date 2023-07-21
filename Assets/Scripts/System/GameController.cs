using UI;
using UnityEngine;

namespace System
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

            if (UIDayControl.DayControl.Day % 3 == 1)
            {
                SpawnEnemy(pos1.position, UIDayControl.DayControl.Day / 3 + 1);
                if (!levelNull)
                {
                    SpawnEnemy(pos2.position, UIDayControl.DayControl.Day / 3);
                    SpawnEnemy(pos3.position, UIDayControl.DayControl.Day / 3);
                }
            }
            else if (UIDayControl.DayControl.Day % 3 == 2)
            {
                if (!levelNull)
                    SpawnEnemy(pos1.position, UIDayControl.DayControl.Day / 3);
                SpawnEnemy(pos2.position, UIDayControl.DayControl.Day / 3 + 1);
                SpawnEnemy(pos3.position, UIDayControl.DayControl.Day / 3 + 1);
            }
            else if (UIDayControl.DayControl.Day % 3 == 0)
            {
                SpawnEnemy(pos1.position, UIDayControl.DayControl.Day / 3);
                SpawnEnemy(pos2.position, UIDayControl.DayControl.Day / 3);
                SpawnEnemy(pos3.position, UIDayControl.DayControl.Day / 3);
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

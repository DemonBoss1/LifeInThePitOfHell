using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool _gameIsPaused = false;
        [SerializeField] private GameObject pauseMenuUI;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            _gameIsPaused = false;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            _gameIsPaused = true;
        }
        public void ExitGame()
        {
            GameController.EnemyCounter = 0;
            PlatformController.PlatformControllerNull();
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}


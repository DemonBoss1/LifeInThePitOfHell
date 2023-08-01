using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UI
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject warningNewGame;

        public void WarningNewGameOn()
        {
            warningNewGame.SetActive(true);
        }

        public void WarningNewGameOff()
        {
            warningNewGame.SetActive(false);

        }
        public void NewGame()
        {
            SerializationBinaryFormatter.DeleteData();
            PlayGame();
        }
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    
    
    }
}

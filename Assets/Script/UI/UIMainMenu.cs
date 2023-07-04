using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.UI
{
    public class UIMainMenu : MonoBehaviour
    {
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

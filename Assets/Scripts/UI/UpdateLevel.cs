using TMPro;
using UnityEngine;

namespace UI
{
    public class UpdateLevel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;
        public void LevelUp(int level)
        {
            levelText.text = "Level: " + level;
        }
    }
}

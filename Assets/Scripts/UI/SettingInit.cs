using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class SettingInit : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;

        private void Start()
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0));
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityIndex", QualitySettings.GetQualityLevel()));
        }
    }
}

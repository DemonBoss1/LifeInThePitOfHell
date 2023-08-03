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

            int resolutionIndex = PlayerPrefs.GetInt("resolutionIndex", -1);
            if (resolutionIndex != -1)
            {
                Resolution[] resolutions = Screen.resolutions;
                Resolution resolution = resolutions[resolutionIndex];
                Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            }
        }
    }
}

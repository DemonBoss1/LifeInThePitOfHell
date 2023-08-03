using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class UISettings : MonoBehaviour
    {
        private float _volume;
        private int _qualityIndex;
        
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Dropdown dropdown;

        public void SetVolume(float volume)
        {
            _volume = volume;
            audioMixer.SetFloat("volume", volume);
        }

        public void SetQuality(int qualityIndex)
        {
            _qualityIndex = qualityIndex;
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        private void Start()
        {
            _volume = PlayerPrefs.GetFloat("volume", 0);
            slider.value = _volume;
            _qualityIndex = PlayerPrefs.GetInt("qualityIndex", QualitySettings.GetQualityLevel());
            dropdown.value = _qualityIndex;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat("volume", _volume);
            PlayerPrefs.SetInt("qualityIndex", _qualityIndex);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class UISettings : MonoBehaviour
    {
        private float _volume;
        
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider slider;

        public void SetVolume(float volume)
        {
            _volume = volume;
            audioMixer.SetFloat("volume", volume);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        private void Start()
        {
            _volume = PlayerPrefs.GetFloat("volume", 0);
            slider.value = _volume;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat("volume", _volume);
        }
    }
}

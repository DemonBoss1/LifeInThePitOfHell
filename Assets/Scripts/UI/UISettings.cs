using System;
using System.Collections.Generic;
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
        private int _resolutionIndex;
        
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Dropdown qualityDropdown;
        [SerializeField] private TMP_Dropdown resolutionDropdown;

        private Resolution[] _resolutions;

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

        public void SetResolution(int resolutionIndex)
        {
            _resolutionIndex = resolutionIndex;
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        private void Start()
        {
            _volume = PlayerPrefs.GetFloat("volume", 0);
            slider.value = _volume;
            
            _qualityIndex = PlayerPrefs.GetInt("qualityIndex", QualitySettings.GetQualityLevel());
            qualityDropdown.value = _qualityIndex;

            _resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            int indexCurrentResolution = 0;
            for (int i = 0; i < _resolutions.Length; i++)
            {
                string option = _resolutions[i].width + " x " + _resolutions[i].height;
                options.Add(option);

                if (_resolutions[i].width == Screen.currentResolution.width &&
                    _resolutions[i].height == Screen.currentResolution.height)
                {
                    indexCurrentResolution = i;
                }
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = indexCurrentResolution;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat("volume", _volume);
            PlayerPrefs.SetInt("qualityIndex", _qualityIndex);
            PlayerPrefs.SetInt("resolutionIndex", _resolutionIndex);
        }
    }
}

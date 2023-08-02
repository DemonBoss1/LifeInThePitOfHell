using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class VolumeInit : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;

        private void Start()
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0));
        }
    }
}

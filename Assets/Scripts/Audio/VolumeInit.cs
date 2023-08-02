using UnityEngine;
using UnityEngine.Audio;

namespace Audio
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

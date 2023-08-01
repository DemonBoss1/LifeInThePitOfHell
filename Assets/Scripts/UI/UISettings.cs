using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class UISettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }
    }
}

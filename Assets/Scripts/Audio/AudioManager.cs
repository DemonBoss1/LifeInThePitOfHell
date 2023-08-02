using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _clip;

        public Sound[] sounds;
        private void Awake()
        {
            if (_clip == null) _clip = this;
        }

        public static Sound GetAudio(string name)
        {
            Sound s = Array.Find(_clip.sounds, sound => sound.name == name);
            return s;
        }

        public static void PlayAudio(string name, AudioSource audioSource)
        {
            Sound sound = GetAudio(name);
            if (sound == null)
            {
                print("Sound Error " + name);
            }
            else
            {
                audioSource.volume = sound.volume;
                audioSource.pitch = sound.pitch;
                audioSource.loop = sound.loop;
                audioSource.PlayOneShot(sound.clip);
            }
        }
    }
}

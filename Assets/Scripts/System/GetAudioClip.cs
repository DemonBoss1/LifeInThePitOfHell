using UnityEngine;

namespace System
{
    public class GetAudioClip : MonoBehaviour
    {
        public static GetAudioClip Clip;
        
        public AudioClip swingSword;
        public AudioClip blowBody;
        public AudioClip bodyCut;

        private void Awake()
        {
            if (Clip == null) Clip = this;
        }
    }
}

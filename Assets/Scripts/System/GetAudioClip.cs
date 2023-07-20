using UnityEngine;

namespace System
{
    public class GetAudioClip : MonoBehaviour
    {
        public static GetAudioClip Clip;
        
        public AudioClip swingSword;
        public AudioClip blowBody;

        private void Awake()
        {
            if (Clip == null) Clip = this;
        }
    }
}

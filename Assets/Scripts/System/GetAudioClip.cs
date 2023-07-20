using UnityEngine;

namespace System
{
    public class GetAudioClip : MonoBehaviour
    {
        public static GetAudioClip Clip;
        
        public AudioClip swingSword;

        private void Awake()
        {
            if (Clip == null) Clip = this;
        }
    }
}

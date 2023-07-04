using UnityEngine;

namespace Script
{
    public class Dead : MonoBehaviour
    {
        [SerializeField] HitPoints HP;
        [SerializeField] GameObject projectilePrefab;

        [SerializeField] private AudioClip bodyCut;

        private bool _isPlayAudio;
        private float _playAudioTimer;
        void Update()
        {
            if((HP.HP <= 0)&&(!_isPlayAudio)){
                playAudio();
                _isPlayAudio = true;
                _playAudioTimer = 1.0f;
            }

            if (_isPlayAudio)
            {
                _playAudioTimer -= Time.deltaTime;
                if (_playAudioTimer < 0)
                {
                    Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
        void playAudio()
        {
            AudioSource audioPlayer = GetComponent<AudioSource>();
            if (audioPlayer != null)
            {
                audioPlayer.PlayOneShot(bodyCut);
            }
        }
    }
}

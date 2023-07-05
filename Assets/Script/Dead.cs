using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class Dead : MonoBehaviour
    {
        [SerializeField] HitPoints HP;
        [SerializeField] GameObject projectilePrefab;

        [SerializeField] private AudioClip bodyCut;

        private bool _isPlayAudio;
        private float _playAudioTimer;
        
        [SerializeField] private GameObject DeadUI;

        void Update()
        {
            if((HP.HP <= 0)&&(!_isPlayAudio)){
                playAudio();
                _isPlayAudio = true;
                _playAudioTimer = 1.0f;
                if (HP.IsPlayer)
                {
                    DeadUI.SetActive(true);
                    PlayerController.TurnOffControlls();
                }
            }

            if (_isPlayAudio)
            {
                _playAudioTimer -= Time.deltaTime;
                if (_playAudioTimer < 0)
                {
                    if (!HP.IsPlayer)
                    {
                        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        SceneManager.LoadScene(0);
                    }
                    
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

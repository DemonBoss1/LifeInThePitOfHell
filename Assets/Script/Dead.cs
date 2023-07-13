using Script.System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script
{
    public class Dead : MonoBehaviour
    {
        [FormerlySerializedAs("HP")] [SerializeField] HitPoints hp;
        [SerializeField] GameObject projectilePrefab;

        [SerializeField] private AudioClip bodyCut;

        private bool _isPlayAudio;
        private float _playAudioTimer;
        
        [FormerlySerializedAs("DeadUI")] [SerializeField] private GameObject deadUI;

        private GameObject _player;
        private CharacterCharacteristics _characteristics;
        private AudioSource _audioPlayer;

        private void Start()
        {
            _audioPlayer = GetComponent<AudioSource>();
        }

        private void Awake() {
            _player = GameObject.FindGameObjectWithTag("Player");
            _characteristics = _player.GetComponent<CharacterCharacteristics>();
        }
        void Update()
        {
            if((hp.Hp <= 0)&&(!_isPlayAudio)){
                PlayAudio();
                _isPlayAudio = true;
                _playAudioTimer = 1.0f;
                if (hp.IsPlayer)
                {
                    deadUI.SetActive(true);
                    ControllerCanvas.TurnOffControlls(false);
                    SerializationBinaryFormatter.DeleteData();
                }
            }

            if (_isPlayAudio)
            {
                _playAudioTimer -= Time.deltaTime;
                if (_playAudioTimer < 0)
                {
                    if (!hp.IsPlayer)
                    {
                        Meal meal = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Meal>();
                        meal.value = Mathf.RoundToInt(GetComponent<CharacterCharacteristics>().MAXHitPoint / 3);
                        _characteristics.GETXp(GetComponent<CharacterCharacteristics>().Level * 5);
                        Destroy(gameObject);
                        GameController.gameController.WallCheck();
                        GameController.EnemyCounter--;
                    }
                    else
                    {
                        GameController.EnemyCounter = 0;
                        SceneManager.LoadScene(0);
                    }
                    
                }
            }
        }
        void PlayAudio()
        {
            if (_audioPlayer != null)
            {
                _audioPlayer.PlayOneShot(bodyCut);
            }
        }
    }
}

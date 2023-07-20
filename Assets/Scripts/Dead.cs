using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Dead : MonoBehaviour
{
    private bool _isPlayAudio;
    private float _playAudioTimer;
        
    [SerializeField] private GameObject deadUI;
    [SerializeField] private GameObject projectilePrefab;

    private GameObject _player;
    private CharacterCharacteristics _characteristics;
    private AudioSource _audioPlayer;
    private HitPoints _hp;
    private PlayerController _playerController;

    private void Start()
    {
        _audioPlayer = GetComponent<AudioSource>();
    }

    private void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _characteristics = _player.GetComponent<CharacterCharacteristics>();
        _hp = _player.GetComponent<HitPoints>();
        _playerController = _player.GetComponent<PlayerController>();
    }
    void Update()
    {
        if((_hp.Hp <= 0)&&(!_isPlayAudio)){
            PlayAudio();
            _isPlayAudio = true;
            _playAudioTimer = 1.0f;
            if (_playerController != null) 
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
                if (_playerController == null) 
                {
                    Meal meal = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Meal>();
                    meal.value = Mathf.RoundToInt(GetComponent<CharacterCharacteristics>().MAXHitPoint / 3);
                    _characteristics.GETXp(GetComponent<CharacterCharacteristics>().Level * 5);
                    Destroy(gameObject);
                    GameController.EnemyCounter--;
                    GameController.gameController.WallCheck();
                }
                else
                {
                    GameController.EnemyCounter = 0;
                    PlatformController.PlatformControllerNull();
                    SceneManager.LoadScene(0);
                }
                    
            }
        }
    }
    void PlayAudio()
    {
        if (_audioPlayer != null)
        {
            _audioPlayer.PlayOneShot(GetAudioClip.Clip.bodyCut);
        }
    }
}
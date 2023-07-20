using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HitPoints : MonoBehaviour
{
    public float Hp => currentHitPoints;
    [SerializeField] private float currentHitPoints;
    [SerializeField] private float timeInvincible = 2.0f;
    private bool _isInvincible;
    private float _invincibleTimer;
    [SerializeField] private bool isPlayer;
    [HideInInspector] public bool triggered;
    [HideInInspector] public bool eat;

    [SerializeField] private CharacterCharacteristics characteristics;
    [SerializeField] private Text hpCount;

    public bool IsPlayer => isPlayer;

    public AudioClip blowBody;
    private UIHealthBar _uiHealthBar;
    private AudioSource _audioPlayer;

    void Start()
    {
        _audioPlayer = GetComponent<AudioSource>();
        _uiHealthBar = GetComponent<UIHealthBar>();
        if (isPlayer)
        {
            Serialization data = SerializationBinaryFormatter.LoadData();
            if (data != null)
            {
                currentHitPoints = data.currentHp;
                _uiHealthBar.SetValue(currentHitPoints / data.maxHitPoint);
            }
            else
            {
                currentHitPoints = characteristics.MAXHitPoint;
            }

            characteristics.currentHp = currentHitPoints;
        }
        else
        {
            currentHitPoints = characteristics.MAXHitPoint;
        }
    }

    void Update()
    {
        if(_isInvincible){
            _invincibleTimer -= Time.deltaTime;
            if(_invincibleTimer < 0)
                _isInvincible = false;
        }
    }
    public void ChangeHp(float value){
        if(value < 0){
            if(_isInvincible) 
                return;
            _isInvincible = true;
            _invincibleTimer = timeInvincible * characteristics.Dexterity;
            if (currentHitPoints + value > 0) PlayAudio();
            value = Mathf.Min(0, value + characteristics.Protection);
                
        }
        currentHitPoints = Mathf.Clamp(currentHitPoints + value, 0, characteristics.MAXHitPoint);
        characteristics.currentHp = currentHitPoints;
        if (isPlayer) _uiHealthBar.SetValue(currentHitPoints / characteristics.MAXHitPoint);
        else SetValue(currentHitPoints / characteristics.MAXHitPoint);
    }

    void PlayAudio()
    {
        if (_audioPlayer != null)
        {
            _audioPlayer.PlayOneShot(blowBody);
        }
    }

    public void Eat()
    {
        eat = true;
    }
    public void SetValue(float value){
        _uiHealthBar.SetValue(currentHitPoints / characteristics.MAXHitPoint);
        hpCount.text = Mathf.RoundToInt(currentHitPoints) + "/" +  Mathf.RoundToInt(characteristics.MAXHitPoint);
    }
}
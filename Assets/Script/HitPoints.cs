using Script.System;
using Script.UI;
using UnityEngine;

namespace Script
{
    public class HitPoints : MonoBehaviour
    {
        public float HP => currentHitPoints;
        [SerializeField]float currentHitPoints;
        [SerializeField] float timeInvincible = 2.0f;
        bool isInvincible;
        float invincibleTimer;
        [SerializeField]bool isPlayer;
        [HideInInspector] public bool triggered;
        [HideInInspector] public bool eat;

        [SerializeField] private CharacterCharacteristics characteristics;

        public bool IsPlayer => isPlayer;

        public AudioClip blowBody;
        void Start()
        {
            if (isPlayer)
            {
                Serialization data = SerializationBinaryFormatter.LoadData();
                if (data != null)
                {
                    currentHitPoints = data.currentHP;
                    UIHealthBar.instance.SetValue(currentHitPoints / data.MAXHitPoint);
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
            if(isInvincible){
                invincibleTimer -= Time.deltaTime;
                if(invincibleTimer < 0)
                    isInvincible = false;
            }
        }
        public void changeHP(float value){
            if(value < 0){
                if(isInvincible) 
                    return;
                isInvincible = true;
                invincibleTimer = timeInvincible * characteristics.Dexterity;
                if (currentHitPoints + value > 0) playAudio();
                print(value);
                value = Mathf.Min(0, value + characteristics.Protection);
                
            }
            currentHitPoints = Mathf.Clamp(currentHitPoints + value, 0, characteristics.MAXHitPoint);
            characteristics.currentHp = currentHitPoints;
            if(isPlayer) UIHealthBar.instance.SetValue(currentHitPoints/characteristics.MAXHitPoint);

            Debug.Log(currentHitPoints + "/" + characteristics.MAXHitPoint);
        }

        void playAudio()
        {
            AudioSource audioPlayer = GetComponent<AudioSource>();
            if (audioPlayer != null)
            {
                audioPlayer.PlayOneShot(blowBody);
            }
        }

        public void Eat()
        {
            eat = true;
        }
        void heal(int value){
        
        }
        void damage(int value){
        
        }
    }
}

using Script.UI;
using UnityEngine;

namespace Script
{
    public class HitPoints : MonoBehaviour
    {
        [SerializeField]int maxHitPoints;
        public int HP{get{return currentHitPoints;} set{}}
        [SerializeField]int currentHitPoints;
        [SerializeField] float timeInvincible = 2.0f;
        bool isInvincible;
        float invincibleTimer;
        [SerializeField]bool isPlayer;
        public bool triggered;
        public bool eat;

        public bool IsPlayer => isPlayer;

        public AudioClip blowBody;
        void Start()
        {
            currentHitPoints = maxHitPoints;
        }

        void Update()
        {
            if(isInvincible){
                invincibleTimer -= Time.deltaTime;
                if(invincibleTimer < 0)
                    isInvincible = false;
            }
        }
        public void changeHP(int value){
            if(value < 0){
                if(isInvincible) 
                    return;
                isInvincible = true;
                invincibleTimer = timeInvincible;
                if (currentHitPoints + value > 0) playAudio();
            }
            currentHitPoints = Mathf.Clamp(currentHitPoints + value, 0, maxHitPoints);
            if(isPlayer) UIHealthBar.instance.SetValue(currentHitPoints/(float)maxHitPoints);

            Debug.Log(currentHitPoints + "/" + maxHitPoints);
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

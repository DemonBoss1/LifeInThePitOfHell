using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField]int maxHitPoints;
    int currentHitPoints;
    [SerializeField] float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
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
        }
        currentHitPoints = Mathf.Clamp(currentHitPoints + value, 0, maxHitPoints);
        UIHealthBar.instance.SetValue(currentHitPoints/(float)maxHitPoints);

        Debug.Log(currentHitPoints + "/" + maxHitPoints);
    }
    void heal(int value){
        
    }
    void damage(int value){
        
    }
}

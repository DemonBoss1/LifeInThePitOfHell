using System;
using UnityEngine;

namespace Script
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] float damage;

        [SerializeField] private CharacterCharacteristics characteristics;

        private void Start()
        {
            if (characteristics != null) damage = characteristics.Attack;
        }

        void OnCollisionStay2D(Collision2D other)
        {
            HitPoints character = other.gameObject.GetComponent<HitPoints>();
            if(character != null){
                character.ChangeHp(-damage);
            }
        }
    }
}

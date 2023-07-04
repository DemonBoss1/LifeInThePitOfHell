using UnityEngine;

namespace Script
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] int damage;
        void Start()
        {
        
        }

        void Update()
        {
        
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            HitPoints character = other.gameObject.GetComponent<HitPoints>();
            if(character != null){
                character.changeHP(-damage);
            }
        }
    }
}

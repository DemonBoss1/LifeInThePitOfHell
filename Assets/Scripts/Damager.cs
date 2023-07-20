using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage;

    [SerializeField] private CharacterCharacteristics characteristics;

    private Dead _dead;

    private void Start()
    {
        if (characteristics != null) damage = characteristics.Attack;
        _dead = GetComponent<Dead>();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (_dead != null && _dead.IsDead) ;
        else
        {
            HitPoints character = other.gameObject.GetComponent<HitPoints>();
            if (character != null)
            {
                character.ChangeHp(-damage);
            }
        }
    }
}
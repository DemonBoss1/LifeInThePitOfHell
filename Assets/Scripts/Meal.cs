using UnityEngine;

public class Meal : MonoBehaviour
{
    public int value;
    private bool _triggered;
    private HitPoints _character;
    void OnTriggerEnter2D(Collider2D other)
    {
        _character = other.GetComponent<HitPoints>();
        if(_character != null)
        {
            _triggered = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        _character = null;
        _triggered = false;
    }
    public void Eat()
    {
        if (_triggered)
        {
            _character.ChangeHp(value);
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class Meal : MonoBehaviour
{
    [SerializeField]int value;
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

    private void Update()
    {
        if (_triggered && _character != null)
        {
            if(Input.GetKeyDown(KeyCode.E)){
                _character.changeHP(value);
                Destroy(gameObject);
            }
        }
    }
}

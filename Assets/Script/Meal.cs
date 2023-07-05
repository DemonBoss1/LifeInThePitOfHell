using UnityEngine;

namespace Script
{
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
                _character.triggered = true;
            }
        }
        void OnTriggerExit2D(Collider2D other)
        {
            _character.triggered = false;
            _character = null;
            _triggered = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Eat();
            }

            if (_character != null)
            {
                if (_character.eat == true)
                {
                    _character.eat = false;
                    Eat();
                }
            }
        }

        public void Eat()
        {
            if (_triggered && _character != null)
            {
                _character.changeHP(value);
                Destroy(gameObject);
            }
        }
    }
}

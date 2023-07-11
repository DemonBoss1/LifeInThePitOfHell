using Script.UI;
using UnityEngine;

namespace Script.System
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] Transform destination;
        private GameObject _player;
        private CharacterCharacteristics _characteristics;
        private void Awake() {
            _player = GameObject.FindGameObjectWithTag("Player");
            _characteristics = _player.GetComponent<CharacterCharacteristics>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                UIDayControl.DayControl.NextDay();
                UIDayEvent.DayEvent.PlayEvent();
                _player.transform.position = destination.transform.position;
                _characteristics.SaveData();
                GameController.gameController.SpawnEnemies();
            }
        }
    }
}

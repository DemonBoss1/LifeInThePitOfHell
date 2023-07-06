using Script.UI;
using UnityEngine;

namespace Script.System
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] Transform destination;
        private GameObject player;
        private CharacterCharacteristics _characteristics;
        private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player");
            _characteristics = player.GetComponent<CharacterCharacteristics>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (EnemyCounter.count == 0)
            {
                if (other.CompareTag("Player"))
                {
                    UIDayControl.DayControl.NextDay();
                    UIDayEvent.DayEvent.PlayEvent();
                    player.transform.position = destination.transform.position;
                    _characteristics.SaveData();
                    GameController.gameController.SpawnEmpty();
                }
            }
        }
    }
}

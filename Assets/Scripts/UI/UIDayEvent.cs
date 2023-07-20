using UnityEngine;

namespace UI
{
    public class UIDayEvent : MonoBehaviour
    {
        [SerializeField] float timeEvent = 1.0f;
        public static UIDayEvent DayEvent;

        [SerializeField] private GameObject eventPanel;

        private void Awake()
        {
            DayEvent = this;
        }
        public void PlayEvent()
        {
            eventPanel.SetActive(true);
            Invoke("EndEvent", timeEvent);
        }
        private void EndEvent()
        {
            eventPanel.SetActive(false);
        }
    }
}

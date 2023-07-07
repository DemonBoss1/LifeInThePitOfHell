using Script.System;
using TMPro;
using UnityEngine;

namespace Script.UI
{
    public class UIDayControl : MonoBehaviour
    {
        private int _day = 1;
        public int Day => _day;
        [SerializeField] private TextMeshProUGUI textUp;
        [SerializeField] private TextMeshProUGUI textPanel;
        public static UIDayControl DayControl;

        private void Awake()
        {
            DayControl = this;
            Serialization data = SerializationBinaryFormatter.LoadData();
            if (data != null)
            {
                _day = data.day;
            }
            textUp.text = "Day " + _day;
            textPanel.text = "Day " + _day;
        }

        public void NextDay()
        {
            _day++;
            textUp.text = "Day " + _day;
            textPanel.text = "Day " + _day;
        }
    }
}

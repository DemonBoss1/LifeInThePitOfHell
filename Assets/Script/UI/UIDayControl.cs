using System;
using Script.System;
using TMPro;
using UnityEngine;

namespace Script.UI
{
    public class UIDayControl : MonoBehaviour
    {
        public static UIDayControl DayControl;
        
        private int _day = 1;
        public int Day => _day;
        
        [SerializeField] private TextMeshProUGUI textUp;
        [SerializeField] private TextMeshProUGUI textPanel;

        private void Awake()
        {
            DayControl = this;
        }

        private void Start()
        {
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

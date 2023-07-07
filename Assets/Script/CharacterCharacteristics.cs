using System;
using Script.System;
using Script.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class CharacterCharacteristics : MonoBehaviour
    {
        [SerializeField]private float _attack = 2;

        public float Attack => _attack;

        [SerializeField]private float _protection = 1;

        public float Protection => _protection;

        [SerializeField]private float _dexterity = 1;

        public float Dexterity => _dexterity;

        [SerializeField]private float _maxHitPoint = 5;

        public float MAXHitPoint => _maxHitPoint;

        private int _requiredXp = 10;
        private int _currentXp = 0;
        [SerializeField] private int _level = 1;
        public int Level => _level;
        public float currentHp;
        [SerializeField] private bool mob;

        [SerializeField] private TextMeshProUGUI levelUI;
        private void Awake()
        {
            if (!mob)
            {
                Serialization data = SerializationBinaryFormatter.LoadData();
                if (data != null)
                {
                    _attack = data.Attack;
                    _protection = data.Protection;
                    _dexterity = data.Dexterity;
                    _maxHitPoint = data.MAXHitPoint;
                    _currentXp = data.currentXP;
                    _requiredXp = data.requiredXP;
                    _level = data.level;
                    levelUI.text = "Level: " + _level;
                }
            }
        }
        void LevelUp()
        {
            _attack *= 1.2f;
            _protection *= 1.2f;
            _dexterity *= 1.01f;
            _maxHitPoint *= 1.2f;
            _level += 1;
            if (!mob)
            {
                SaveData();
                levelUI.text = "Level: " + _level;
            }
            else levelUI.text = "Level: " + _level;
        }

        public void getXP(int value)
        {
            _currentXp += value;
            while (_currentXp > _requiredXp)
            {
                _currentXp -= _requiredXp;
                _requiredXp *= 2;
                LevelUp();
            }
        }

        public void setLevel(int level)
        {
            _attack = 2;
            _protection = 1;
            _dexterity = 1;
            _maxHitPoint = 5;
            _requiredXp = 10;
            int index = 1;
            while (index < level)
            {
                _requiredXp *= 2;
                LevelUp();
                index++;
            }
        }

        public void SaveData()
        {
            Serialization data = new Serialization(_attack, _protection, _dexterity, _maxHitPoint, _currentXp, 
                _requiredXp,_level, UIDayControl.DayControl.Day, currentHp);
            SerializationBinaryFormatter.SaveData(data);
        }
        public void SaveDataDead()
        {
            Serialization data = new Serialization(_attack, _protection, _dexterity, _maxHitPoint, _currentXp,
                _requiredXp, _level, UIDayControl.DayControl.Day / 2, _maxHitPoint * 0.1f);
            SerializationBinaryFormatter.SaveData(data);
        }
    }
}

using System;
using Script.System;
using UnityEngine;

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
        private Serialization _data;
        [SerializeField] private SerializationBinaryFormatter serialization;
        private void Start()
        {
            Serialization data = serialization.LoadData();
            if (data != null)
            {
                _attack = data.Attack;
                _protection = data.Protection;
                _dexterity = data.Dexterity;
                _maxHitPoint = data.MAXHitPoint;
                _currentXp = data.currentXP;
                _requiredXp = data.requiredXP;
            }
        }
        void LevelUp()
        {
            _attack *= 1.5f;
            _protection *= 1.5f;
            _dexterity *= 1.1f;
            _maxHitPoint *= 1.5f;
            _data = new Serialization(_attack, _protection, _dexterity, _maxHitPoint, _currentXp, _requiredXp);
            serialization.SaveData(_data);
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
    }
}

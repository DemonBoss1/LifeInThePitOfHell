using UnityEngine;

namespace Script
{
    public class CharacterCharacteristics : MonoBehaviour
    {
        private float _attack = 1;

        public float Attack => _attack;

        private float _protection = 1;

        public float Protection => _protection;

        private float _dexterity = 1;

        public float Dexterity => _dexterity;

        private float _maxHitPoint = 5;

        public float MAXHitPoint => _maxHitPoint;

        private int _requiredXp = 10;
        private int _currentXp = 0;

        void LevelUp()
        {
            _attack *= 1.1f;
            _protection *= 1.1f;
            _dexterity *= 1.1f;
            _dexterity *= 1.1f;
        }

        public void getXP(int value)
        {
            _currentXp += value;
            if (_currentXp > _requiredXp)
            {
                _currentXp -= _requiredXp;
                _requiredXp *= 2;
                LevelUp();
            }
        }
    }
}

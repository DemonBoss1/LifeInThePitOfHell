using UnityEngine;

namespace Script
{
    public class CharacterCharacteristics : MonoBehaviour
    {
        private float attack = 1;

        public float Attack => attack;

        private float protection = 1;

        public float Protection => protection;

        private float _dexterity = 1;

        public float Dexterity => _dexterity;

        private float _maxHitPoint = 5;

        public float MAXHitPoint => _maxHitPoint;

        void levelUp()
        {
            attack *= 1.1f;
            protection *= 1.1f;
            _dexterity *= 1.1f;
            _dexterity *= 1.1f;
        }
    }
}

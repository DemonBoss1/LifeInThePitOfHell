using UnityEngine.Serialization;

namespace System
{
    [Serializable]
    public class Serialization
    {
        [FormerlySerializedAs("Attack")] public float attack;
        [FormerlySerializedAs("Protection")] public float protection;
        [FormerlySerializedAs("Dexterity")] public float dexterity;
        [FormerlySerializedAs("MAXHitPoint")] public float maxHitPoint;
        [FormerlySerializedAs("currentHP")] public float currentHp;
        [FormerlySerializedAs("currentXP")] public int currentXp;
        [FormerlySerializedAs("requiredXP")] public int requiredXp;
        public int level, day;

        public Serialization(float a, float p, float d, float hp, int cXp, int rXp, int lvl, int day, float cHp)
        {
            attack = a;
            protection = p;
            dexterity = d;
            maxHitPoint = hp;
            currentXp = cXp;
            requiredXp = rXp;
            level = lvl;
            this.day = day;
            currentHp = cHp;
        }
    }
}

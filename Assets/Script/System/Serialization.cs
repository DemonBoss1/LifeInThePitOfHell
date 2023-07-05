using System;

namespace Script.System
{
    [Serializable]
    public class Serialization
    {
        public float Attack, Protection, Dexterity, MAXHitPoint;
        public int currentXP, requiredXP;

        public Serialization(float a, float p, float d, float hp, int cXP, int rXP)
        {
            Attack = a;
            Protection = p;
            Dexterity = d;
            MAXHitPoint = hp;
            currentXP = cXP;
            requiredXP = rXP;
        }
    }
}

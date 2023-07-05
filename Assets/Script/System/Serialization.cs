using System;

namespace Script.System
{
    [Serializable]
    public class Serialization
    {
        public float Attack, Protection, Dexterity, MAXHitPoint, currentHP;
        public int currentXP, requiredXP, level, day;

        public Serialization(float a, float p, float d, float hp, int cXP, int rXP, int lvl, int day, float cHP)
        {
            Attack = a;
            Protection = p;
            Dexterity = d;
            MAXHitPoint = hp;
            currentXP = cXP;
            requiredXP = rXP;
            level = lvl;
            this.day = day;
            currentHP = cHP;
        }
    }
}

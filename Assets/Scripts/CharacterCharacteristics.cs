using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterCharacteristics : MonoBehaviour
{
    [FormerlySerializedAs("_attack")] [SerializeField] private float attack = 2;

    public float Attack => attack;

    [FormerlySerializedAs("_protection")] [SerializeField]private float protection = 1;

    public float Protection => protection;

    [FormerlySerializedAs("_dexterity")] [SerializeField]private float dexterity = 1;

    public float Dexterity => dexterity;

    [FormerlySerializedAs("_maxHitPoint")] [SerializeField]private float maxHitPoint = 5;

    public float MAXHitPoint => maxHitPoint;

    private int _requiredXp = 10;
    private int _currentXp = 0;
    [FormerlySerializedAs("_level")] [SerializeField] private int level = 1;
    public int Level => level;
    public float currentHp;
    [SerializeField] private bool mob;
    public static int PlayerLevel;

    private UpdateLevel _levelUp;
    private void Awake()
    {
        if (!mob)
        {
            Serialization data = SerializationBinaryFormatter.LoadData();
            if (data != null)
            {
                attack = data.attack;
                protection = data.protection;
                dexterity = data.dexterity;
                maxHitPoint = data.maxHitPoint;
                _currentXp = data.currentXp;
                _requiredXp = data.requiredXp;
                level = data.level;
            }
            PlayerLevel = level;
        }
        _levelUp = GetComponent<UpdateLevel>();
        _levelUp.LevelUp(level);
    }

    void LevelUp()
    {
        attack = Mathf.Round(attack * 1.2f) + 1;
        protection = Mathf.Round(protection * 1.1f) + 1;
        dexterity = dexterity * 1.01f;
        maxHitPoint = Mathf.Round(maxHitPoint * 1.2f) + 1;
        level += 1;
        _requiredXp *= 2;
        if (!mob)
        {
            SaveData();
            PlayerLevel = level;
        }
        _levelUp.LevelUp(level);
    }

    public void GETXp(int value)
    {
        _currentXp += value;
        while (_currentXp > _requiredXp)
        {
            _currentXp -= _requiredXp;
            LevelUp();
        }
    }

    public void SetLevel(int level)
    {
        if (level > 1)
        {
            attack = 2;
            protection = 1;
            dexterity = 1;
            maxHitPoint = 5;
            _requiredXp = 10;
            for (int i = 1; i < level; i++) LevelUp();
        }
    }

    public void SaveData()
    {
        Serialization data = new Serialization(attack, protection, dexterity, maxHitPoint, _currentXp, 
            _requiredXp,level, UIDayControl.DayControl.Day, currentHp);
        SerializationBinaryFormatter.SaveData(data);
    }
}
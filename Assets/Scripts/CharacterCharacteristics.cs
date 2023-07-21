using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterCharacteristics : MonoBehaviour
{
    private float _attack = 2;
    public float Attack => _attack;

    private float _protection = 1;
    public float Protection => _protection;

    private float _dexterity = 1;
    public float Dexterity => _dexterity;

    private float _maxHitPoint = 5;
    public float MAXHitPoint => _maxHitPoint;

    private int _requiredXp = 10;
    private int _currentXp = 0; 
    
    private int _level = 1;
    public int Level => _level;

    private HitPoints _hitPoints;
    private EnemyController _enemyController;

    private UpdateLevel _levelTextBar;
    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        if (_enemyController == null) 
        {
            Serialization data = SerializationBinaryFormatter.LoadData();
            if (data != null)
            {
                _attack = data.attack;
                _protection = data.protection;
                _dexterity = data.dexterity;
                _maxHitPoint = data.maxHitPoint;
                _currentXp = data.currentXp;
                _requiredXp = data.requiredXp;
                _level = data.level;
            }
        }
        _levelTextBar = GetComponent<UpdateLevel>();
        _hitPoints = GetComponent<HitPoints>();
        _levelTextBar.LevelUp(_level);
    }

    void LevelUp()
    {
        _attack = Mathf.Round(_attack * 1.2f) + 1;
        _protection = Mathf.Round(_protection * 1.1f) + 1;
        _dexterity = _dexterity * 1.01f;
        _maxHitPoint = Mathf.Round(_maxHitPoint * 1.2f) + 1;
        _level += 1;
        _requiredXp *= 2;
        if (_enemyController == null) 
        {
            SaveData();
            _hitPoints.SetValue();
        }
        _levelTextBar.LevelUp(_level);
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
            _attack = 2;
            _protection = 1;
            _dexterity = 1;
            _maxHitPoint = 5;
            _requiredXp = 10;
            for (int i = 1; i < level; i++) LevelUp();
        }
    }

    public void SaveData()
    {
        Serialization data = new Serialization(_attack, _protection, _dexterity, _maxHitPoint, _currentXp, 
            _requiredXp,_level, UIDayControl.DayControl.Day, _hitPoints.Hp);
        SerializationBinaryFormatter.SaveData(data);
    }
}
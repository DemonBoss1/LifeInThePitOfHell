using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController
{
    private bool _isHit;
    private float _timeHit = 0.5f;
    private float _hitTimer;

    private GameObject _character;
    private LookDirection _lookDirection;
    private CharacterCharacteristics _characteristics;
    
    private AudioSource audioSource;

    public AttackController(GameObject gameObject)
    {
        _character = gameObject;
        audioSource = _character.GetComponent<AudioSource>();
        _lookDirection = _character.GetComponent<LookDirection>();
        _characteristics = _character.GetComponent<CharacterCharacteristics>();
    }

    public void Cooldown()
    {
        if(_isHit){
            _hitTimer -= Time.deltaTime;
            if(_hitTimer < 0)
                _isHit = false;
        }
    }
    public void Attack()
    {
        if(_isHit) 
            return;
        _isHit = true;
        _hitTimer = _timeHit;
        audioSource.PlayOneShot(GetAudioClip.Clip.swingSword);
        Compat.Attack(_character, _lookDirection.Direction, 0.5f, _characteristics.Attack);
        //Debug.Log("Attack");
    }
}

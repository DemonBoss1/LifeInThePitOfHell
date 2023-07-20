using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _speed = 3.0f;
        
    [SerializeField] private Rigidbody2D rigidbody2d;
    
    private PlatformController _platformController;

    private LookDirection _lookDirection;
    private AttackController _attackControl;

    private void Awake()
    {
        _attackControl = new AttackController(gameObject);

    }

    void Start()
    {
        #if UNITY_STANDALONE_WIN
            _platformController = PlatformDesktop.CreatePlatform(_attackControl);
        #elif UNITY_ANDROID
            _platformController = PlatformMobile.CreatePlatform();
        #endif
            _lookDirection = GetComponent<LookDirection>();
    }

    void Update()
    {
        _platformController.Movement();
        _attackControl.Cooldown();
        _lookDirection.UpdateLookDirection (_platformController.Horizontal, _platformController.Vertical);
    }
    private void FixedUpdate() {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + _speed * _platformController.Horizontal * Time.deltaTime;
        position.y = position.y + _speed * _platformController.Vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    public void Attack()
    {
        _attackControl.Attack();
    }

    public Vector2 GetLookDirection()
    {
        return _lookDirection.Direction;
    }
}
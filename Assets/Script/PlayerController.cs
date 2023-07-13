using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        
        float _speed = 3.0f;
        public Vector2 Position => rigidbody2d.position + Vector2.up * 0.5f;
        
        [SerializeField] private Rigidbody2D rigidbody2d;
        
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip swingSword;

        private PlatformController _platformController;
        
        private PlayerRotation _rotation;

        private bool _isHit;
        private float _timeHit = 0.5f;
        private float _hitTimer;
        
        private Vector2 _direction;

        [SerializeField] private CharacterCharacteristics characteristics;

        void Start()
        {
            #if UNITY_STANDALONE_WIN
                _platformController = PlatformDesktop.CreatePlatform();
            #elif UNITY_ANDROID
                _platformController = PlatformMobile.CreatePlatform();
            #endif
            _rotation = GetComponent<PlayerRotation>();
        }

        void Update()
        {
            _platformController.Movement();
            if (_platformController.Horizontal != 0 || _platformController.Vertical != 0)
            {
                _direction = new Vector2(_platformController.Horizontal, _platformController.Vertical).normalized;
            }
            _rotation.Rotate(_direction.x, _direction.y);

            if (Input.GetAxis("Fire1") != 0)
            {
                Attack();
            }
            if(_isHit){
                _hitTimer -= Time.deltaTime;
                if(_hitTimer < 0)
                    _isHit = false;
            }
        }
        private void FixedUpdate() {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + _speed * _platformController.Horizontal * Time.deltaTime;
            position.y = position.y + _speed * _platformController.Vertical * Time.deltaTime;
        
            rigidbody2d.MovePosition(position);
        }

        public void Attack()
        {
            if(_isHit) 
                return;
            _isHit = true;
            _hitTimer = _timeHit;
            audioSource.PlayOneShot(swingSword);
            Compat.Attack(this, _direction, 0.5f, characteristics.Attack);
            //Debug.Log("Attack");
        }

        
    }
}

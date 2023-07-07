using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        float _horizontal;
        float _vertical;
        float _speed = 3.0f;
        public Vector2 Position => rigidbody2d.position + Vector2.up * 0.5f;


        [SerializeField] private Rigidbody2D rigidbody2d;
        [SerializeField] private int damage;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip swingSword;
        [SerializeField] private Joystick joystick;
        [SerializeField] private GameObject controllerCanvas;
        private int _platform;
        private PlayerRotation _rotation;
        public static GameObject ControllerCanvas;

        private bool _isHit;
        private float _timeHit = 0.5f;
        private float _hitTimer;
        private Vector2 _direction;

        [SerializeField] private CharacterCharacteristics characteristics;

        void Start()
        {
            ControllerCanvas = controllerCanvas;
            #if UNITY_STANDALONE_WIN
                PlayerPrefs.SetInt("Platform", 0);
                controllerCanvas.SetActive(false);
            #elif UNITY_ANDROID
                PlayerPrefs.SetInt("Platform", 1);
                controllerCanvas.SetActive(true);
            #endif
            _platform = PlayerPrefs.GetInt("Platform");
            _rotation = GetComponent<PlayerRotation>();
        }

        void Update()
        {
            if(_platform == 0){
                _horizontal = Input.GetAxis("Horizontal");
                _vertical = Input.GetAxis("Vertical");
            }
            else if(_platform == 1){
                _horizontal = joystick.Horizontal;
                _vertical = joystick.Vertical;
            }
            if (_horizontal != 0 || _vertical != 0)
            {
                _direction = new Vector2(_horizontal, _vertical).normalized;
            }
            _rotation.Rotate(_direction.x, _direction.y);

            if (Input.GetAxis("Fire1") != 0 && _platform == 0)
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
            position.x = position.x + _speed * _horizontal * Time.deltaTime;
            position.y = position.y + _speed * _vertical * Time.deltaTime;
        
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

        public static void TurnOffControlls()
        {
            ControllerCanvas.SetActive(false);
        }
    }
}

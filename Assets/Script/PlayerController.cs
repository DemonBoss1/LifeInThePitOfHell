using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        float horizontal;
        float vertical;
        float speed = 3.0f;
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
        private float timeHit = 0.5f;
        private float _hitTimer;
        private Vector2 _direction;

        void Start()
        {
            ControllerCanvas = controllerCanvas;
            #if UNITY_STANDALONE_WIN
                PlayerPrefs.SetInt("Platform", 0);
                controllerCanvas.SetActive(false);
            #elif UNITY_ANDROID
                PlayerPrefs.SetInt("Platform", 1);
            #endif
            _platform = PlayerPrefs.GetInt("Platform");
            _rotation = GetComponent<PlayerRotation>();
        }

        void Update()
        {
            if(_platform == 0){
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
            }
            else if(_platform == 1){
                horizontal = joystick.Horizontal;
                vertical = joystick.Vertical;
            }


            _rotation.Rotate(horizontal, vertical);
            if (horizontal != 0 || vertical != 0)
            {
                _direction = new Vector2(horizontal, vertical).normalized;
            }

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
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;
        
            rigidbody2d.MovePosition(position);
        }

        public void Attack()
        {
            if(_isHit) 
                return;
            _isHit = true;
            _hitTimer = timeHit;
            audioSource.PlayOneShot(swingSword);
            Compat.Attack(this, _direction, 0.5f, damage);
            Debug.Log("Attack");
        }

        public static void TurnOffControlls()
        {
            ControllerCanvas.SetActive(false);
        }
    }
}

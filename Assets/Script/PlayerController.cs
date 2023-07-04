using UnityEngine;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        float horizontal;
        float vertical;
        float speed = 3.0f;
        public Vector2 Position => rigidbody2d.position + Vector2.up * 0.5f;


        [SerializeField] private Rigidbody2D rigidbody2d;
        [SerializeField] private Animator animator;

        [SerializeField] private int damage;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip swingSword;
        
        private bool _isHit;
        private float timeHit = 0.5f;
        private float _hitTimer;

        void Start()
        {
        
        }

        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            animator.SetFloat("Move X", horizontal);
            animator.SetFloat("Move Y", vertical);

            if (Input.GetAxis("Fire1") != 0)
            {
                if(_isHit) 
                    return;
                _isHit = true;
                _hitTimer = timeHit;
                audioSource.PlayOneShot(swingSword);
                Compat.Attack(this, new Vector2(horizontal, vertical), 0.5f, damage);
                Debug.Log("Attack");
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
    }
}

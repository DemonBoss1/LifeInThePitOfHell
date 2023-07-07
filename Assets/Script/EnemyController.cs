using UnityEngine;

namespace Script
{
    public class EnemyController : MonoBehaviour
    {
        private Transform _player;
        [SerializeField] private float speed;
        private Rigidbody2D _rb;
        private PlayerRotation _rotation;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _rb = GetComponent<Rigidbody2D>();
            _rotation = GetComponent<PlayerRotation>();
        }

        private void Update()
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            _rb.velocity = direction * speed;
            _rotation.Rotate(direction.x, direction.y);
        }
    }
}

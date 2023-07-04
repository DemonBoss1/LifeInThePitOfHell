using UnityEngine;

namespace Script
{
    public class EnemyController : MonoBehaviour
    {
        private Transform _player;
        [SerializeField] private float speed;
        private Rigidbody2D rb;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }
}

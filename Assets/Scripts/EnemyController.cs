using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private LookDirection _lookDirection;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        _lookDirection = GetComponent<LookDirection>();
    }

    private void Update()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = direction * speed;
        _lookDirection.Rotate(direction.x, direction.y);
    }
}
using UnityEngine;

namespace Script
{
    public class CameraController : MonoBehaviour
    {
        private Transform _player;
        [SerializeField] private float speed;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void FixedUpdate()
        {
            Vector3 targetPos = _player.position;
            targetPos.z = -10;
            targetPos.y += 2;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        }
    }
}

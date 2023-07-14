using UnityEngine;

namespace Script
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Sprite left, right, down, up;
        [SerializeField] private SpriteRenderer playerSprite;

        private Vector2 _direction;

        public Vector2 Direction => _direction;

        public void UpdateLookDirection(float horizontal, float vertical)
        {
            if (horizontal != 0 || vertical != 0)
            {
                _direction = new Vector2(horizontal, vertical).normalized;
                Rotate(_direction.x, _direction.y);
            }
        }
        public void Rotate(float rotationX, float rotationY)
        {
            rotationX = Mathf.Round(rotationX);
            rotationY = Mathf.Round(rotationY);
            if (rotationX > 0 && rotationY == 0)
            {
                playerSprite.sprite = right;
            }
            else if (rotationX < 0 && rotationY == 0)
            {
                playerSprite.sprite = left;
            }
            else if (rotationX == 0 && rotationY > 0)
            {
                playerSprite.sprite = up;
            }
            else if (rotationX == 0 && rotationY < 0)
            {
                playerSprite.sprite = down;
            }
        }
    }
}

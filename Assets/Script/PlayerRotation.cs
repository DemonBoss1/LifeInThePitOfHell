using UnityEngine;

namespace Script
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Sprite left, right, down, up;
        [SerializeField] private SpriteRenderer playerSprite;

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

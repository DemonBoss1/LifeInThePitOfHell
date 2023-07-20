using UnityEngine;

namespace System
{
    public class FrameRate : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 120;
        }
    }
}

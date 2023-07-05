using UnityEngine;

namespace Script.System
{
    public class FrameRate : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 120;
        }
    }
}

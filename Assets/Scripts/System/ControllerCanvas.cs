using Joystick_Pack.Scripts.Base;
using UnityEngine;

namespace System
{
    public class ControllerCanvas : MonoBehaviour
    {
        [SerializeField] private Joystick joystickControl;

        [SerializeField] private GameObject controllerCanvas;
        private static ControllerCanvas _controllerCanvas;

        //private ControllerCanvas() { }

        private void Awake()
        {
            _controllerCanvas = this;
        }

        public static void TurnOffControlls(bool isActive)
        {
            _controllerCanvas.controllerCanvas.SetActive(isActive);
        }

        public static Joystick GetJoystick()
        {
            return _controllerCanvas.joystickControl;
        }
    }
}

using Joystick_Pack.Scripts.Base;
using UnityEngine;

namespace System
{
    public class PlatformMobile : PlatformController
    {
        private Joystick _joystick;

        private PlatformMobile()
        {
            ControllerCanvas.TurnOffControlls(true);
            _joystick = ControllerCanvas.GetJoystick();
            _platformController = this;
        }

        public static PlatformController CreatePlatform()
        {
            if (_platformController == null)
            {
                _platformController = new PlatformMobile();
            }
            return _platformController;
        }
        public override void Movement()
        {
            _horizontal = _joystick.Horizontal;
            _vertical = _joystick.Vertical;
        }
    }
}
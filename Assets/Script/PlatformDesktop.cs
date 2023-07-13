using Script.System;
using UnityEngine;

namespace Script
{
    public class PlatformDesktop : PlatformController
    {
        private static PlatformController _platformController;
        private PlatformDesktop(){}
        public static PlatformController CreatePlatform()
        {
            if (_platformController == null)
            {
                ControllerCanvas.TurnOffControlls(false);
                _platformController = new PlatformDesktop();
            }
            return _platformController;
        }
        public override void Movement()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }
    }
}

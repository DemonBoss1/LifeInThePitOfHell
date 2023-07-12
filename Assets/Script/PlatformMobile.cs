namespace Script
{
    public class PlatformMobile : PlatformController
    {
        private Joystick _joystick;
        private static PlatformController _platformController;

        private PlatformMobile(Joystick joystick)
        {
            if (_platformController == null)
            {
                _joystick = joystick;
                _platformController = this;
            }
        }

        public static PlatformController CreatePlatform(Joystick joystick)
        {
            if (_platformController == null)
            {
                _platformController = new PlatformMobile(joystick);
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

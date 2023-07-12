namespace Script
{
    public class PlatformMobile : PlatformController
    {
        private Joystick _joystick;

        PlatformMobile(Joystick joystick)
        {
            _joystick = joystick;
        }
        public override void Movement()
        {
            _horizontal = _joystick.Horizontal;
            _vertical = _joystick.Vertical;
        }
    }
}

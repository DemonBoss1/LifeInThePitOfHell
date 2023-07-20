using UnityEngine;

namespace System
{
    public class PlatformDesktop : PlatformController
    {
        private AttackController _attackControl;
        private PlatformDesktop(AttackController attackControl)
        {
            _attackControl = attackControl;
        }
        public static PlatformController CreatePlatform(AttackController attackControl)
        {
            if (_platformController == null)
            {
                ControllerCanvas.TurnOffControlls(false);
                _platformController = new PlatformDesktop(attackControl);
            }
            return _platformController;
        }
        public override void Movement()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            if (Input.GetAxis("Fire1") != 0)
            {
                _attackControl.Attack();
            }
        }
    }
}
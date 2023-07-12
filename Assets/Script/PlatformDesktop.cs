using UnityEngine;

namespace Script
{
    public class PlatformDesktop : PlatformController
    {
        public override void Movement()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }
    }
}

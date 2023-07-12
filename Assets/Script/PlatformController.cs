using UnityEngine;

namespace Script
{
    public abstract class PlatformController
    {
        protected float _horizontal;
        protected float _vertical;

        public float Horizontal => _horizontal;
        public float Vertical => _vertical;

        public abstract void Movement();
    }
}

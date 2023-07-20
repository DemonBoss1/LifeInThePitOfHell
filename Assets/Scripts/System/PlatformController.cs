namespace System
{
    public abstract class PlatformController
    {
        protected float _horizontal;
        protected float _vertical;
        public float Horizontal => _horizontal;
        public float Vertical => _vertical;
        

        protected static PlatformController _platformController;
        
        public abstract void Movement();

        public static void PlatformControllerNull()
        {
            _platformController = null;
        }
    }
}
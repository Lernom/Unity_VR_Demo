using UnityEngine;

namespace InteractionDemo.Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    class GrabbableObject : MonoBehaviour
    {
        protected Grabber _currentGrabber;
       
        public virtual void Grab(Grabber newGrabber)
        {
            if(_currentGrabber != null)
                _currentGrabber.Release();
            _currentGrabber = newGrabber;
        }

        public virtual void Release(Grabber grabber)
        {
            if(_currentGrabber == grabber)
            {                
                _currentGrabber = null;
            }
        }
    }
}

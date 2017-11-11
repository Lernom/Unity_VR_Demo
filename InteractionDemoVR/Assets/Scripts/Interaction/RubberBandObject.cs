using UnityEngine;

namespace InteractionDemo.Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    class RubberBandObject : GrabbableObject
    {
        private int _collisionCounter = 0;

        private bool _armSpring = false;

        private bool _detectedCollision = false;

        public override void Release(Grabber grabber)
        {
            TurnSpringOff();
            base.Release(grabber);
        }

        void FixedUpdate()
        {
            if (_currentGrabber == null)
                return;
            if (_detectedCollision)
                _armSpring = true;
            
            if(_armSpring && _detectedCollision)
            {
                TurnSpringOn();
            }
            if(_armSpring && !_detectedCollision)
            {
                TurnSpringOff();
                _armSpring = false;
            }
            _detectedCollision = false;
        }

        void TurnSpringOn()
        {
            if (_currentGrabber != null)
            {
                _currentGrabber.GrabJoint.linearLimitSpring = new SoftJointLimitSpring() { spring = GetComponent<Rigidbody>().mass * 10000 };
                _currentGrabber.GrabJoint.linearLimit = new SoftJointLimit() { limit = 0.001f };
            }
        }
        
        void TurnSpringOff()
        {
            if (_currentGrabber != null)
            {
                _currentGrabber.GrabJoint.linearLimitSpring = new SoftJointLimitSpring();
                _currentGrabber.GrabJoint.linearLimit = new SoftJointLimit();
            }
        }

        void OnCollisionEnter(Collision c)
        {
            _detectedCollision = true;
        }

        void OnCollisionStay(Collision c)
        {
            _detectedCollision = true;
        }

    }
}

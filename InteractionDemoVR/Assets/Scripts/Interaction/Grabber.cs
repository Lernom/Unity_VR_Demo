using InteractionDemo.Core;
using UnityEngine;


namespace InteractionDemo.Interaction
{
    [RequireComponent(typeof(TrackedController), typeof(Scanner))]
    class Grabber: MonoBehaviour
    {
        public float ReleaseDistance = 20f;

        private bool IsGrabbing = false;

        private TrackedController _controller;

        private Scanner _scanner;

        public GrabbableObject GrabbedObject;

        public ConfigurableJoint GrabJoint;

        private float _grabbedMagnitude;

        void Start()
        {
            _controller = GetComponent<TrackedController>();
            _controller.OnTriggerDown += TryGrab;
            _controller.OnTriggerUp += Release;
            _scanner = GetComponent<Scanner>();
        }

        void Update()
        {
            if (IsGrabbing)
            {
                var currentDistance = Mathf.Abs(_grabbedMagnitude - (GrabJoint.transform.position - GrabJoint.connectedBody.transform.position).sqrMagnitude);

                if (currentDistance > ReleaseDistance)
                {                 
                    Release();
                }
            }
        }

        public void Release()
        {
            if (IsGrabbing)
            {
                IsGrabbing = false;
                Debug.Log("Released " + GrabbedObject.name);
                GrabJoint.connectedBody = null;
                GrabbedObject.GetComponent<Rigidbody>().angularVelocity = _controller.Controller.angularVelocity;
                GrabbedObject.GetComponent<Rigidbody>().velocity = _controller.Controller.velocity;
                GrabbedObject.Release(this);
                GrabbedObject = null;
                _grabbedMagnitude = 0;
            }
        }

        private void Release(TrackedController sender, float TriggerValue)
        {
            Release();
        }

        private void TryGrab(TrackedController sender, float TriggerValue)
        {
            if(IsGrabbing)
            {
                Debug.Log("Grabber is Grabbing already, something went wrong");
                return;
            }
          
            var toGrab = _scanner.GetClosestInterractableObject();
            if(toGrab != null)
            {
              
                var grabbedObject = toGrab.GetComponent<GrabbableObject>();
                if (grabbedObject != null)
                {
                    GrabbedObject = grabbedObject;
                    IsGrabbing = true;
                    GrabJoint.connectedBody = GrabbedObject.GetComponent<Rigidbody>();
                    GrabbedObject.Grab(this);
                    Debug.Log("Grabbed " + GrabbedObject.name);
                    _grabbedMagnitude = (GrabJoint.transform.position - GrabJoint.connectedBody.transform.position).sqrMagnitude;
                }
            }
           
        }
    }
}

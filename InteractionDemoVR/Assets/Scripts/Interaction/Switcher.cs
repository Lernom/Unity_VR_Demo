using InteractionDemo.Core;
using UnityEngine;


namespace InteractionDemo.Interaction
{
    [RequireComponent(typeof(TrackedController), typeof(Scanner))]
    class Switcher : MonoBehaviour
    {
        private Scanner _scanner;

        private TrackedController _controller;

        void Start()
        {
            _controller = GetComponent<TrackedController>();
            _controller.OnTriggerDown += TryPush;
            _scanner = GetComponent<Scanner>();           
        }            
        
        private void TryPush(TrackedController sender, float TriggerValue)
        {          
            var toPush = _scanner.GetClosestInterractableObject();
            if(toPush != null)
            {
              
                var pushedObject = toPush.GetComponent<ISwitchable>();
                if (pushedObject != null)
                {
                    pushedObject.Switch();
                    Debug.Log("Pushed " + toPush.name);
                }
            }
           
        }
    }
}

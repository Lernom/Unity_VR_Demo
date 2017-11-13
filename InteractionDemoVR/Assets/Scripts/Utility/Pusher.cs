using UnityEngine;

namespace InteractionDemo.Interaction
{
      /// <summary>
      /// Special class to push objects to initial position
      /// </summary>
     [RequireComponent(typeof(Rigidbody))]
    class Pusher : MonoBehaviour
    {
        public Vector3 PushDirection;

        public float PushPower;

        void Start()
        {
            GetComponent<Rigidbody>().AddRelativeForce(PushDirection * PushPower);
        }
    }
}

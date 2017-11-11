using InteractionDemo.Core;
using System.Collections.Generic;
using UnityEngine;


namespace InteractionDemo.Interaction
{
    [RequireComponent(typeof(Collider))]
    class Scanner: MonoBehaviour
    {
        private HashSet<Transform> InteractableObjects;        

        void Awake()
        {
            InteractableObjects = new HashSet<Transform>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == Strings.TAG_INTERACTABLE)
            {
                InteractableObjects.Add(other.transform);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.transform.tag == Strings.TAG_INTERACTABLE)
            {
                InteractableObjects.Remove(other.transform);
            }
        }

        public Transform GetClosestInterractableObject()
        {
            float magnitude = float.MaxValue;
            Transform closest = null;
            foreach (var item in InteractableObjects)
            {
                if((item.GetComponent<Collider>().bounds.center - transform.position).sqrMagnitude < magnitude)
                {
                    closest = item;
                }
            }
            return closest;
        }
    }
}

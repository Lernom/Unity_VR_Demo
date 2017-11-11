using System;
using UnityEngine;

namespace InteractionDemo.Core
{
    /// <summary>
    /// Class for body
    /// </summary>
    [RequireComponent(typeof(CapsuleCollider))]
    public class BodyRig : MonoBehaviour
    {
        private CapsuleCollider _collider;

        public Transform CameraPoint;

        void Start()
        {
            _collider = GetComponent<CapsuleCollider>(); 
        }

        void FixedUpdate()
        {
            transform.localPosition = new Vector3(CameraPoint.transform.position.x, CameraPoint.transform.position.y / 2, CameraPoint.transform.position.z);
            _collider.height = CameraPoint.transform.position.y / 2;
        }



    }
}

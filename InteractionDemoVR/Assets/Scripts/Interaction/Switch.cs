using InteractionDemo.Core;
using System;
using UnityEngine;

namespace InteractionDemo.Interaction
{
    /// <summary>
    /// Class of hinged switches
    /// </summary>
    [RequireComponent(typeof(HingeJoint))]
    class Switch : MonoBehaviour, ISwitchable
    {
        public float OnPosition;

        public float OffPosition;

        public bool InitialyOn;

        private HingeJoint _joint;        

        public bool IsOn
        {
            get
            {
                return _isOn;
            }
            set
            {
                _isOn = value;
                ConfigureSpring();
                OnSwitchEvent.Invoke(IsOn);
            }
        }

        private bool _isOn = true;

        public SwitcherEvent OnSwitchEvent;

        void Start()
        {
            _joint = GetComponent<HingeJoint>();
            IsOn = InitialyOn;
        }

        private void ConfigureSpring()
        {
            _joint.spring = new JointSpring() { spring = 1, targetPosition = _isOn ?  OnPosition :OffPosition};           
        }

        void ISwitchable.Switch()
        {
            IsOn = !IsOn;
        }
    }
}

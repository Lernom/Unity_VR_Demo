using InteractionDemo.Core;
using UnityEngine;

namespace InteractionDemo.Interaction
{
    class Lever : MonoBehaviour
    {
        public HingeJoint LeverJoint;

        public Transform LeverHandle;

        private float _value, _minValue, _maxValue;

        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = Mathf.Clamp01(value);
                LeverHandle.localRotation = Quaternion.Euler(0, 0, (_maxValue - _minValue) * _value);
            }
        }
     
        public delegate void LeverValueChangedEventHandler(float newValue);

        public LeverEvent onLeverValueChanged;

        void Start()
        {
            _minValue = LeverJoint.limits.min;
            _maxValue = LeverJoint.limits.max;
        }

        void Update()
        {
            if (LeverHandle.hasChanged)
            {
                var newValue = GetValue();
                if (_value != newValue)
                {
                    _value = newValue;
                    onLeverValueChanged.Invoke(Value);
                }
                LeverHandle.hasChanged = false;
            }
        }

        private float GetValue()
        {
            return Mathf.InverseLerp(_minValue, _maxValue, LeverHandle.localRotation.eulerAngles.z);
        }
    }

}

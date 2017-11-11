﻿using System;
using UnityEngine;

namespace InteractionDemo.Core
{
    [RequireComponent(typeof(SteamVR_TrackedObject))]
    public class TrackedController : MonoBehaviour
    {
        SteamVR_TrackedObject TrackedObject;

        public event TriggerEventHandler OnTriggerPress;

        public event TriggerEventHandler OnTriggerUp;

        public event TriggerEventHandler OnTriggerDown;

        public event ButtonEventHandler OnGripDown;
        
        public event ButtonEventHandler OnGripUp;

        public SteamVR_Controller.Device Controller
        {
            get
            {
                return SteamVR_Controller.Input((int)TrackedObject.index);
            }
        }

        public bool IsInitialized
        {
            get
            {
                return Controller != null;
            }
        }

        void Start()
        {
            TrackedObject = GetComponent<SteamVR_TrackedObject>();
        }

        void Update()
        {
            if (!IsInitialized)
                return;
            if (Controller.GetHairTrigger())
            {
                if (OnTriggerPress != null)
                {
                    OnTriggerPress(this, Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
                }
            }
            if (Controller.GetHairTriggerUp())
            {
                if (OnTriggerUp != null)
                {
                    OnTriggerUp(this, 0);
                }
            }

            if (Controller.GetHairTriggerDown())
            {
                if (OnTriggerDown != null)
                {
                    OnTriggerDown(this, 1);
                }
            }

            if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                if (OnGripDown != null)
                {
                    OnGripDown(this, true);
                }
            }

            if (Controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                if (OnGripUp != null)
                {
                    OnGripUp(this, false);
                }
            }
        }

       
    }
}

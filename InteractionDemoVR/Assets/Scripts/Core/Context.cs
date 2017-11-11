using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace InteractionDemo.Core
{    
    class Context : SingletonBehaviour<Context>
    {
        protected Context() {}

        private Valve.VR.EVRButtonId Trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

        public event EventHandler OnTriggerPress;

        public TrackedController LeftController;

        public TrackedController RightController;

        void Start()
        {
            
        }
        

        void Update()
        {

        }

        private void Context_OnTriggerPress(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

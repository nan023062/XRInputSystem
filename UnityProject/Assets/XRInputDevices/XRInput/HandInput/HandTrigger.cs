﻿using UnityEngine.XR;

namespace NaveXR.InputDevices
{
    public class HandTrigger : HandInputBase
    { 
        public HandTrigger() :base(XRKeyCode.Trigger)
        {

        }

        public override void UpdateState(UnityEngine.XR.InputDevice device)
        {
            bool lastPressed = mPressed;
            float lastForce = mKeyForce;

            device.TryGetFeatureValue(CommonUsages.trigger, out mKeyForce);
            mTouched = isTouched(mKeyForce);

            //这里不使用UnityXR的按钮状态，因为会有感官上的延迟
            //device.TryGetFeatureValue(CommonUsages.triggerButton, out mPressed);
            mPressed = OptimizPressByKeyForce(lastForce, mKeyForce, 0.0001f, 0.2f, 0.6f);
            mBoolDown = !lastPressed && mPressed;
            mBoolUp = lastPressed && !mPressed;
        }
    }
}

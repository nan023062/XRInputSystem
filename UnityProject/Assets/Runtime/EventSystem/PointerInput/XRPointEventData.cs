﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace NaveXR.InputDevices
{
    public class XRPointEventData : PointerEventData
    {
        public XRPointEventData(EventSystem eventSystem) :base(eventSystem)
        {

        }

        public Vector3 origin;

        public Vector3 direction;

        public float hitDistance;

        public Vector3 hitPoint;

        public Vector3 hitNormal;

        [Range(0f,1f)] public float force;

        public bool useFingerRaycast = false;

        public Camera raycastCamera;

        public static FramePressState StateForButton(bool pressed, bool released)
        {
            if (pressed && released)
                return FramePressState.PressedAndReleased;
            if (pressed)
                return FramePressState.Pressed;
            if (released)
                return FramePressState.Released;
            return FramePressState.NotChanged;
        }

    }
}

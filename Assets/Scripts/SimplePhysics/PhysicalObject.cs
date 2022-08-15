using System;
using UnityEngine;

namespace SimplePhysics
{
    public class PhysicalObject:MonoBehaviour
    {
        public Vector2 Speed = Vector2.zero;
        public Vector2 Acceleration = Vector2.zero;
        public float Friction;

        private void Start()
        {
            PhysicsManager.Instance().SubscribeObject(this);
        }

        private void OnDestroy()
        {
            PhysicsManager.Instance().UnSubscribeObject(this);
        }
    }
}
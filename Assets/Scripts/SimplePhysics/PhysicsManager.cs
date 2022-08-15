using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimplePhysics
{
    public class PhysicsManager
    {
        private static PhysicsManager instance;
        private List<PhysicalObject> subscribedObjects = new List<PhysicalObject>();

        public static PhysicsManager Instance()
        {
            if (instance == null)
            {
                instance = new PhysicsManager();
            }

            return instance;
        }

        public void SubscribeObject(PhysicalObject physicalObject)
        {
            subscribedObjects.Add(physicalObject);
        }

        public void UnSubscribeObject(PhysicalObject physicalObject)
        {
            subscribedObjects.Remove(physicalObject);
        }

        public void UpdatePhysics()
        {
            foreach (var subscribedObject in subscribedObjects)
            {
                if (subscribedObject.Speed.magnitude > 0.001f)
                {
                    subscribedObject.Speed *= subscribedObject.Friction;
                }
                subscribedObject.Speed += subscribedObject.Acceleration * Time.deltaTime;
                var deltaPos = subscribedObject.Speed * Time.deltaTime;
                var transform = subscribedObject.transform;
                var position = transform.position;
                position = new Vector3(position.x + deltaPos.x, position.y + deltaPos.y);
                transform.position = position;
            }
        }
    }
}
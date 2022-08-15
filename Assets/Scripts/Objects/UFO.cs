using SimplePhysics;
using UnityEngine;

namespace Objects
{
    public class UFO : MonoBehaviour
    {
        [SerializeField] private float chasingSpeedMax;
        [SerializeField] private float chasingAcceleration;
        [SerializeField] private PhysicalObject physicalObject;

        public Transform Target { get; set; }

        void Update()
        {
            if (physicalObject.Speed.magnitude < chasingSpeedMax)
            {
                physicalObject.Acceleration =
                    new Vector2(Target.position.x - transform.position.x, Target.position.y - transform.position.y)
                        .normalized * chasingAcceleration;
            }
            else
            {
                physicalObject.Acceleration = Vector2.zero;
            }
        }
    }
}
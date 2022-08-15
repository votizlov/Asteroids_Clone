using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimplePhysics
{
    public class PhysicsUpdater : MonoBehaviour
    {
        private PhysicsManager physicsManager;
        private void Start()
        {
            physicsManager = PhysicsManager.Instance();
            StartCoroutine(UpdatePhysics());
        }

        private IEnumerator UpdatePhysics()
        {
            while (true)
            {
                physicsManager.UpdatePhysics();
                yield return null;
            }
        }
    }
}

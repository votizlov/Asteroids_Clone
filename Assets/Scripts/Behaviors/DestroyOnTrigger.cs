using System;
using UnityEngine;

namespace Behaviors
{
    public class DestroyOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(gameObject);
        }
    }
}

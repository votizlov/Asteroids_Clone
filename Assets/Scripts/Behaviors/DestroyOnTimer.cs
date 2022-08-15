using System;
using System.Collections;
using UnityEngine;

namespace Behaviors
{
    public class DestroyOnTimer : MonoBehaviour
    {
        [SerializeField] private float time;

        private void Start()
        {
            StartCoroutine(Timer());
        }

        IEnumerator Timer()
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}

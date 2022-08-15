using System;
using SimplePhysics;
using UnityEngine;

namespace Objects
{
    public class BigMeteorite : MonoBehaviour
    {
        [SerializeField] private float initialSpeed;
        [SerializeField] private PhysicalObject physicalObject;
        
        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] private float spawnRadius;
        [SerializeField] private float launchSpeed;

        private void OnEnable()
        {
            physicalObject.Speed = new Vector2(-transform.position.x, -transform.position.y).normalized * initialSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            LaunchMeteor((transform.position + transform.up* spawnRadius) ,
                new Vector2(transform.up.normalized.x, transform.up.normalized.y));
            LaunchMeteor((transform.position + transform.right* spawnRadius) * spawnRadius,
                new Vector2(transform.right.normalized.x, transform.right.normalized.y));
            LaunchMeteor((transform.position - transform.right* spawnRadius) ,
                new Vector2(-transform.right.normalized.x, -transform.right.normalized.y));
        }

        private void LaunchMeteor(Vector3 pos, Vector2 dir)
        {
            Instantiate(objectToSpawn, pos, Quaternion.identity).GetComponent<PhysicalObject>().Speed = dir * launchSpeed;
        }
    }
}
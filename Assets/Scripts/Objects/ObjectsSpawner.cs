using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects
{
    public class ObjectsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToSpawn;
        [SerializeField] private PolygonCollider2D[] spawnArea;

        [SerializeField] private float spawnFrequency;
        public Transform Target;


        void OnEnable()
        {
            StartCoroutine(Spawn());
        }

        private void OnDisable()
        {
            StopCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                int areaIndex = Random.Range(0, spawnArea.Length);
                Vector3 spawnPos = Vector3.Lerp(spawnArea[areaIndex].bounds.min,
                    spawnArea[areaIndex].bounds.max, Random.value);
                int prefabIndex = Random.Range(0, objectsToSpawn.Length);
                var t = Instantiate(objectsToSpawn[prefabIndex],
                    spawnPos, Quaternion.identity);
                if (prefabIndex == 1)
                {
                    t.GetComponent<UFO>().Target = Target;
                }

                //spawnArea[Random.Range(0,spawnArea.Length)].bounds.max
                yield return new WaitForSeconds(spawnFrequency);
            }
        }
    }
}
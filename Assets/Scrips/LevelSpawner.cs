using System.Collections.Generic;
using UnityEngine;

namespace Scrips
{
    public class LevelSpawner : MonoBehaviour
    {
        public GameObject[] trackPrefabs;
        public float spawnZ = 0;
        public float segmentLength = 20f;
        public int initialSegments = 5;
        public Transform player;
        private Queue<GameObject> spawnedSegments = new();

        void Start()
        {
            for (int i = 0; i < initialSegments; i++)
            {
                SpawnSegment();
            }
        }

        void Update()
        {
            if (player.position.z - 20 > spawnZ - initialSegments * segmentLength)
            {
                SpawnSegment();
                DeleteOldSegment();
            }
        }

        void SpawnSegment()
        {
            GameObject seg = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Length)], Vector3.forward * spawnZ, Quaternion.identity);
            spawnZ += segmentLength;
            spawnedSegments.Enqueue(seg);
        }

        void DeleteOldSegment()
        {
            GameObject old = spawnedSegments.Dequeue();
            Destroy(old);
        }
    }
}
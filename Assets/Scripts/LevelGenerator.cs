﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform player;

    public List<GameObject> chunks = new List<GameObject>();
    public int chunkSize = 20;
    public int maxSpawnedObjects = 3;

    int nextSpawn = 0;

    Queue<GameObject> spawnedObjects = new Queue<GameObject>();
    Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

    void Update()
    {
        if (player.position.x >= nextSpawn)
            Spawn();
    }

    void Spawn()
    {
        nextSpawn += chunkSize;

        var go = GetInstance(chunks[Random.Range(0, chunks.Count)]); //get available instance

        go.transform.position = new Vector3(nextSpawn, 0.0f); //set position
        go.SetActive(true); //activate

        spawnedObjects.Enqueue(go); //keep track

        if (spawnedObjects.Count > maxSpawnedObjects)
            spawnedObjects.Dequeue().SetActive(false); //despawn last
    }

    GameObject GetInstance(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
            pools.Add(prefab, new List<GameObject>()); //add list

        var instance = pools[prefab].FirstOrDefault(go => !go.activeSelf); //get first inactive

        if (!instance)
        {
            instance = Instantiate(prefab, transform); //instantiate if not available
            pools[prefab].Add(instance); //add to pool
        }

        return instance;
    }
}

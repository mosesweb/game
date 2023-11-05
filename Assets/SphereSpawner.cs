using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // The prefab of the sphere you want to spawn.
    public float spawnInterval = 2.0f; // Time interval between spawns.
    private float nextSpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnSphere();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnSphere()
    {
        // Instantiate a new sphere at the spawn point's position.
        GameObject newSphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);

        // Make sure to set the player reference for the SphereRoll script in the newly spawned sphere.
        EnemySphere enemySphere = newSphere.GetComponent<EnemySphere>();
        if (enemySphere != null)
        {
            enemySphere.player = GameObject.Find("Player");
        }
    }
}

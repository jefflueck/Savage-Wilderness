using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{


    public GameObject objectToSpawn; // Assign your prefab here

    public int numberOfObjects = 5;



    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        Terrain terrain = FindObjectOfType<Terrain>(); // Find the active terrain
        if (terrain == null)
        {
            Debug.LogError("No terrain found in the scene!");
            return;
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            // 1. Generate random X and Z positions within the defined range
            float randomX = Random.Range(terrain.transform.position.x, terrain.transform.position.x + terrain.terrainData.size.x);
            float randomZ = Random.Range(terrain.transform.position.z, terrain.transform.position.z + terrain.terrainData.size.z);

            // 2. Create a temporary position vector with an arbitrary Y value
            Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ);
            // 3. Get the exact terrain height at that X and Z position
            float terrainHeight = terrain.SampleHeight(spawnPosition);
            // 4. Set the Y position to the terrain height plus an optional offset
            spawnPosition.y = terrainHeight + terrain.transform.position.y;
            // 5. Instantiate the object at the calculated position
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, this.transform);
        }
    }
}

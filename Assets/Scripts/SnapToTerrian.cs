using UnityEngine;

public class SnapToTerrain : MonoBehaviour
{
    public Terrain terrain; // Assign your Terrain GameObject here
    public float verticalOffset = 0.1f; // Small offset above the ground

    void Start()
    {
        // Call this to snap objects when the game starts
        SnapObject();
    }

    public void SnapObject()
    {
        if (terrain == null)
        {
            Debug.LogError("Terrain not assigned!" + gameObject.name);
            return;
        }

        // Get the terrain's height at the object's X, Z position
        float terrainHeight = terrain.SampleHeight(transform.position);

        // Set the object's Y position to the sampled height + offset
        transform.position = new Vector3(transform.position.x, terrainHeight + verticalOffset, transform.position.z);
    }
}

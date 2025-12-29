using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSounds : MonoBehaviour
{
    public AudioClip PlayerWalkSound;
    public AudioClip PlayerRunSound;

    private AudioSource audioSource;

    public Terrain terrain;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        FindLayerIndex();
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)
                        || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
                        || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        bool isRunning = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && isMoving;

        if (isRunning)
        {
            if (audioSource.clip != PlayerRunSound)
            {
                audioSource.clip = PlayerRunSound;
                audioSource.loop = true;
                audioSource.volume = 0.5f;
                audioSource.Play();
            }
        }
        else if (isMoving)
        {
            if (audioSource.clip != PlayerWalkSound)
            {
                audioSource.clip = PlayerWalkSound;
                audioSource.loop = true;
                audioSource.volume = 0.5f;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void FindLayerIndex()
    {
        Vector3 playerPosition = transform.position;
        TerrainData terrainData = terrain.terrainData;

        // Convert world position to terrain-relative coordinates
        Vector3 terrainPos = playerPosition - terrain.transform.position;

        // Normalize to alphamap coordinates (0-1 range)
        Vector3 normalizedPos = new Vector3(
            terrainPos.x / terrainData.size.x,
            0,
            terrainPos.z / terrainData.size.z
        );

        // Convert to alphamap array indices
        int mapX = Mathf.FloorToInt(normalizedPos.x * terrainData.alphamapWidth);
        int mapZ = Mathf.FloorToInt(normalizedPos.z * terrainData.alphamapHeight);

        // Get the alphamap at this position (returns float[,,] where last dimension is layer weights)
        float[,,] alphamap = terrainData.GetAlphamaps(mapX, mapZ, 1, 1);

        // Find the dominant layer (highest weight)
        int dominantLayer = 0;
        float maxWeight = 0f;

        for (int i = 0; i < terrainData.alphamapLayers; i++)
        {
            if (alphamap[0, 0, i] > maxWeight)
            {
                maxWeight = alphamap[0, 0, i];
                dominantLayer = i;
            }
        }

        // Debug.Log("Player is on terrain layer index: " + dominantLayer);
    }

    // if player falls below y = -10, restart level
    void LateUpdate()
    {
        if (transform.position.y < 90f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}

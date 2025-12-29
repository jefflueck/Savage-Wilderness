using UnityEngine;
using System.Collections;



public class WolfSounds : MonoBehaviour
{

    public AudioClip WolfHowlSoundOne;
    public AudioClip WolfHowlSoundTwo;
    public AudioClip WolfGrowlSoundOne;
    public AudioClip WolfGrowlSoundTwo;
    public AudioClip WolfAttackSound;

    private AudioClip audioClip;


    private AudioSource audioSource;


    public float distance;

    public float moveSpeed;



    private Transform playerTransform;

    private bool isCheckingDistance = false;

    public Terrain terrain;
    private Rigidbody rb;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        terrain = Terrain.activeTerrain;
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        StartCoroutine(checkDistanceCoroutine());


    }

    void FixedUpdate()
    {
        if (!isCheckingDistance)
        {
            StartCoroutine(checkDistanceCoroutine());
            //    move wolfs at a set random interval
            moveSpeed = Random.Range(5f, 70f);

            // move towards player
            if (playerTransform == null) return;
            Vector3 direction = (playerTransform.position - rb.position).normalized;
            direction.y = 0;
            Vector3 targetPos = rb.position + direction * moveSpeed * Time.deltaTime;

            // Terrain height
            float terrainY = terrain.SampleHeight(targetPos) + terrain.transform.position.y;
            targetPos.y = terrainY;

            rb.MovePosition(targetPos);

            // Terrain normal
            Vector3 terrainLocalPos = targetPos - terrain.transform.position;
            float normX = terrainLocalPos.x / terrain.terrainData.size.x;
            float normZ = terrainLocalPos.z / terrain.terrainData.size.z;
            Vector3 terrainNormal = terrain.terrainData.GetInterpolatedNormal(normX, normZ);

            // Upright rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction, terrainNormal);
            rb.MoveRotation(targetRotation);
        }
    }






    IEnumerator checkDistanceCoroutine()

    {
        isCheckingDistance = true;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance > 30 && distance <= 60 && !audioSource.isPlaying)
            {
                // play howlSound one
                audioClip = WolfHowlSoundOne;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            if (distance <= 30 && distance > 20 && !audioSource.isPlaying)
            {
                // play howlSound two
                audioClip = WolfHowlSoundTwo;
                audioSource.clip = audioClip;
                audioSource.Play();

            }
            if (distance <= 20 && distance > 10 && !audioSource.isPlaying)
            {
                // play growlSound one
                audioClip = WolfGrowlSoundOne;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            if (distance <= 10 && !audioSource.isPlaying)
            {
                // play growlSound two
                audioClip = WolfGrowlSoundTwo;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            if (distance <= 2 && !audioSource.isPlaying)
            {
                // play attack sound
                audioClip = WolfAttackSound;
                audioSource.clip = audioClip;
                audioSource.Play();
            }

            yield return new WaitForSeconds(5.0f);
            isCheckingDistance = false;
        }

    }
}

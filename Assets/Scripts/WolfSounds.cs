using UnityEngine;
using System.Collections;



public class WolfSounds : MonoBehaviour
{

    public AudioClip WolfHowlSoundOne;
    public AudioClip WolfHowlSoundTwo;
    public AudioClip WolfGrowlSoundOne;
    public AudioClip WolfGrowlSoundTwo;

    private AudioClip audioClip;


    private AudioSource audioSource;


    public float distance;

    public float moveSpeed;

    public GameObject wolfWalkingObject;

    private Transform playerTransform;

    private bool isCheckingDistance = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            // do not the y axis movement be below terrain
            direction.y = 0;
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            // keep wolf pointed at player
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);

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
        }

        yield return new WaitForSeconds(5.0f);
        isCheckingDistance = false;
    }

}


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


    private bool isCheckingDistance = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(checkDistanceCoroutine());
    }

    void Update()
    {
        if (!isCheckingDistance)
        {
            StartCoroutine(checkDistanceCoroutine());
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

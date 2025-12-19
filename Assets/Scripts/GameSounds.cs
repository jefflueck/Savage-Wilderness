using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public AudioClip WoodsNightAmbience;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && WoodsNightAmbience != null)
        {
            audioSource.clip = WoodsNightAmbience;
            audioSource.loop = true;
            audioSource.Play();
            audioSource.volume = 0.2f; // Set volume as needed
        }
    }
}

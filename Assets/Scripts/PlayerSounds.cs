using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip PlayerWalkSound;
    public AudioClip PlayerRunSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // play walking sound when tag "Player" is moving without Shift key held down
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                // Running
                if (audioSource.clip != PlayerRunSound)
                {
                    audioSource.clip = PlayerRunSound;
                    audioSource.loop = true;
                    audioSource.Play();
                    audioSource.volume = 0.5f; // Adjust volume for running sound
                }
            }
            else
            {
                // Walking
                if (audioSource.clip != PlayerWalkSound)
                {
                    audioSource.clip = PlayerWalkSound;
                    audioSource.loop = true;
                    audioSource.Play();
                    audioSource.volume = 0.5f; // Adjust volume for walking sound
                }
            }
        }
        else
        {
            // Not moving
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }


}

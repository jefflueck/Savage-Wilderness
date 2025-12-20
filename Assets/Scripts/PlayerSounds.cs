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

    void Update()
    {
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
}

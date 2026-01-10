using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfCollisionHandler : MonoBehaviour
{
    public AudioClip WolfAttackSound;

    private AudioClip audioClip;


    private AudioSource audioSource;

    private WolfSounds wolfSounds;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        wolfSounds = GetComponent<WolfSounds>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play attack sound
            audioSource.PlayOneShot(wolfSounds.WolfAttackSound);
            // destroy player after sound plays
            Destroy(collision.gameObject, wolfSounds.WolfAttackSound.length);
            // reload scene after 2 seconds
            Invoke("ReloadScene", 5f);

        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}


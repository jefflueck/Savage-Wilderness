using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class WolfSounds : MonoBehaviour
{

    public AudioClip WolfHowlSoundOne;
    public AudioClip WolfHowlSoundTwo;
    public AudioClip WolfGrowlSoundOne;
    public AudioClip WolfGrowlSoundTwo;

    private AudioClip audioClip;

    [SerializeField]
    public float distance;


    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {

        float playerDistance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);



    }
}

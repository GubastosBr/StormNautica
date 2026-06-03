using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource AudioSource;

    public AudioClip deathSound;
    public AudioClip checkpointSound;
    public AudioClip collectItem;
    public AudioClip jumpSound;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip audioclip)
    {
        AudioSource.PlayOneShot(audioclip);
    }
}

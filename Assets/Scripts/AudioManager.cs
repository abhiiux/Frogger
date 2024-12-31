using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------------Audio Source----------------")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundAudioSource;

    [Header("----------------Audio Clips----------------")]

    [SerializeField] internal AudioClip backgroundMusicClip;
    [SerializeField] internal AudioClip jumpClip;
    [SerializeField] internal AudioClip coinCollectionClip;
    [SerializeField] internal AudioClip carCrashClip;

    void Start()
    {
        PlayBackgroundMusic();
    }


    public void PlayAudio( AudioClip clip )
    {
        audioSource.PlayOneShot( clip );
    }

    public void PlayBackgroundMusic()
    {
        backgroundAudioSource.clip = backgroundMusicClip;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.Play();
    }
}

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------------Audio Source----------------")]
    [SerializeField] private AudioSource audioSource;

    [Header("----------------Audio Clips----------------")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinCollectionClip;
    [SerializeField] private AudioClip carCrashClip;
    [SerializeField] private AudioClip gameOverClip;

    public void PlayAudio( AudioClip clip )
    {
        audioSource.PlayOneShot( clip );
    }
}

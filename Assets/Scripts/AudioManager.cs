using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------------Audio Source----------------")]
    [SerializeField] private AudioSource audioSource;

    [Header("----------------Audio Clips----------------")]
    [SerializeField] internal AudioClip jumpClip;
    [SerializeField] internal AudioClip coinCollectionClip;
    [SerializeField] internal AudioClip carCrashClip;

    public void PlayAudio( AudioClip clip )
    {
        audioSource.PlayOneShot( clip );
    }
}
using UnityEngine;

public class PlayerHitSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        PlayerEvents.OnPlayerHit += PlaySound;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerHit -= PlaySound;
    }

    void PlaySound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}

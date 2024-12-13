using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] backgroundClips;

    private int currentClipIndex = 0;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = false;
        PlayNextClip();
    }

    void PlayNextClip()
    {
        if (backgroundClips.Length == 0)
        {
            Debug.LogWarning("Nessun clip audio presente in Background Clips!");
            return;
        }

        audioSource.clip = backgroundClips[currentClipIndex];
        Debug.Log("Riproduzione di: " + backgroundClips[currentClipIndex].name + ", Volume: " + audioSource.volume);
        audioSource.Play();

        currentClipIndex = (currentClipIndex + 1) % backgroundClips.Length;

        // Pianifica la prossima clip
        Invoke(nameof(PlayNextClip), audioSource.clip.length);
    }
}
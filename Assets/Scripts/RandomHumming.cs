using System.Collections;
using UnityEngine;

public class RandomHumming : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    [Tooltip("Drag and drop the AudioSource component here.")]
    public AudioSource audioSource;

    private float minPitch = 0.9f;
    private float maxPitch = 1.1f;
    private float minVolume = 0.8f; // Minimale Lautstärke
    private float maxVolume = 1.0f; // Maximale Lautstärke
    private float minDelay = 10.0f; // Minimale Wartezeit zwischen den Soundeffekten in Sekunden
    private float maxDelay = 45.0f; // Maximale Wartezeit zwischen den Soundeffekten in Sekunden

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned. Adding AudioSource component to the GameObject.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        StartCoroutine(PlayRandomSoundWithDelay());
    }

    IEnumerator PlayRandomSoundWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay)); // Wartezeit vor der nächsten Wiedergabe

            // Zufällige Auswahl eines der AudioClips
            int randomSound = Random.Range(1, 4);
            AudioClip clipToPlay = null;

            switch (randomSound)
            {
                case 1:
                    clipToPlay = sound1;
                    break;
                case 2:
                    clipToPlay = sound2;
                    break;
                case 3:
                    clipToPlay = sound3;
                    break;
            }

            if (clipToPlay != null && audioSource != null)
            {
                // Zufällige Pitch-Variation
                float randomPitch = Random.Range(minPitch, maxPitch);
                audioSource.pitch = randomPitch;

                // Zufällige Lautstärke-Variation
                float randomVolume = Random.Range(minVolume, maxVolume);
                audioSource.volume = randomVolume;

                // Spiele den Soundeffekt ab
                audioSource.PlayOneShot(clipToPlay);

                // Warte bis der Soundeffekt zu Ende ist, bevor der nächste gestartet wird
                yield return new WaitForSeconds(clipToPlay.length);
            }
        }
    }
}

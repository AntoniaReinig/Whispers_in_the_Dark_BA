using System.Collections;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] soundClips;  // Array mit 9 AudioClips
    public AudioSource audioSource; // Referenz zur AudioSource

    private float minPitch = 0.9f;
    private float maxPitch = 1.1f;
    private float minVolume = 0.6f;
    private float maxVolume = 1.0f;
    private float minDelay = 25.0f; // Minimale Wartezeit zwischen den Soundeffekten in Sekunden
    private float maxDelay = 60.0f; // Maximale Wartezeit zwischen den Soundeffekten in Sekunden

    void Start()
    {
        // Starte den Coroutine f�r die zuf�llige Wiedergabe der Soundeffekte
        StartCoroutine(PlayRandomSoundWithDelay());
    }

    IEnumerator PlayRandomSoundWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay)); // Wartezeit vor der n�chsten Wiedergabe

            // Zuf�llige Auswahl eines der AudioClips
            int randomIndex = Random.Range(0, soundClips.Length); // Zuf�lliger Index zwischen 0 und der L�nge des Arrays
            AudioClip clipToPlay = soundClips[randomIndex];

            if (clipToPlay != null)
            {
                // Zuf�llige Pitch-Variation
                float randomPitch = Random.Range(minPitch, maxPitch);
                audioSource.pitch = randomPitch;

                // Zuf�llige Lautst�rke-Variation
                float randomVolume = Random.Range(minVolume, maxVolume);
                audioSource.volume = randomVolume;

                // Spiele den Soundeffekt ab
                audioSource.PlayOneShot(clipToPlay);

                // Warte bis der Soundeffekt zu Ende ist, bevor der n�chste gestartet wird
                yield return new WaitForSeconds(clipToPlay.length);
            }
        }
    }
}

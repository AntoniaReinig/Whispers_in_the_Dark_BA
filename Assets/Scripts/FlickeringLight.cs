using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 1f;         // Minimale Lichtintensität
    public float maxIntensity = 2f;         // Maximale Lichtintensität
    public float flickerSpeed = 5f;         // Geschwindigkeit des Flackerns
    public float flickerChance = 0.1f;      // Wahrscheinlichkeit für das Flackern

    private Light _light;                   // Referenz auf das Light-Komponente

    void Start()
    {
        // Zugriff auf das Light-Komponente der aktuellen GameObjects
        _light = GetComponent<Light>();

        // Starten der Coroutine für das gelegentliche Flackern des Lichts
        StartCoroutine(RandomFlicker());
    }

    IEnumerator RandomFlicker()
    {
        while (true)
        {
            // Zufällige Wartezeit zwischen den Flacker-Ereignissen
            float waitTime = Random.Range(1f, 10f);
            yield return new WaitForSeconds(waitTime);

            // Zufällige Entscheidung, ob das Licht flackern soll
            if (Random.value < flickerChance)
            {
                // Zufällige Intensität zwischen minIntensity und maxIntensity
                float randomIntensity = Random.Range(minIntensity, maxIntensity);
                _light.intensity = randomIntensity;

                // Warte für eine zufällige Zeit
                yield return new WaitForSeconds(Random.Range(0.1f, 1f / flickerSpeed));

                // Setze die Intensität zurück
                _light.intensity = maxIntensity; // oder eine Standard-Intensität, die du festlegen möchtest
            }
        }
    }
}

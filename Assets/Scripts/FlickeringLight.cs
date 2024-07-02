using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 1f;         // Minimale Lichtintensit�t
    public float maxIntensity = 2f;         // Maximale Lichtintensit�t
    public float flickerSpeed = 5f;         // Geschwindigkeit des Flackerns
    public float flickerChance = 0.1f;      // Wahrscheinlichkeit f�r das Flackern

    private Light _light;                   // Referenz auf das Light-Komponente

    void Start()
    {
        // Zugriff auf das Light-Komponente der aktuellen GameObjects
        _light = GetComponent<Light>();

        // Starten der Coroutine f�r das gelegentliche Flackern des Lichts
        StartCoroutine(RandomFlicker());
    }

    IEnumerator RandomFlicker()
    {
        while (true)
        {
            // Zuf�llige Wartezeit zwischen den Flacker-Ereignissen
            float waitTime = Random.Range(1f, 10f);
            yield return new WaitForSeconds(waitTime);

            // Zuf�llige Entscheidung, ob das Licht flackern soll
            if (Random.value < flickerChance)
            {
                // Zuf�llige Intensit�t zwischen minIntensity und maxIntensity
                float randomIntensity = Random.Range(minIntensity, maxIntensity);
                _light.intensity = randomIntensity;

                // Warte f�r eine zuf�llige Zeit
                yield return new WaitForSeconds(Random.Range(0.1f, 1f / flickerSpeed));

                // Setze die Intensit�t zur�ck
                _light.intensity = maxIntensity; // oder eine Standard-Intensit�t, die du festlegen m�chtest
            }
        }
    }
}

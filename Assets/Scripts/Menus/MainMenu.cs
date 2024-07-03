using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Diese Methode lädt die nächste Szene im Build-Index
    public void PlayGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // Stelle sicher, dass die nächste Szene im Build existiert, bevor du sie lädst
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Es gibt keine nächste Szene im Build.");
        }
    }

    // Diese Methode beendet die Anwendung
    public void QuitGame()
    {
        Application.Quit();
    }
}

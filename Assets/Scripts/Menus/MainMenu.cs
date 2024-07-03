using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Diese Methode l�dt die n�chste Szene im Build-Index
    public void PlayGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // Stelle sicher, dass die n�chste Szene im Build existiert, bevor du sie l�dst
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Es gibt keine n�chste Szene im Build.");
        }
    }

    // Diese Methode beendet die Anwendung
    public void QuitGame()
    {
        Application.Quit();
    }
}

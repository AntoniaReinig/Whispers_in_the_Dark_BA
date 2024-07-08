using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject pauseMenu;
    private bool isPaused;

    private bool isInMainMenu;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        isInMainMenu = SceneManager.GetActiveScene().name == "MainMenu";
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            isInMainMenu = true;
        }
        else
        {
            isInMainMenu = false;
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;

                // Setze den Mauszeiger
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void Update()
    {
        if (!isInMainMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;

            // Setze den Mauszeiger frei und mache ihn sichtbar
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ResumeGame()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

            // Fixiere und verstecke den Mauszeiger wieder
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

        // Setze den Mauszeiger frei und mache ihn sichtbar
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Deaktiviere das Pause-Menü
            isPaused = false; // Setze den pausierten Zustand zurück
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject pausePanel;

    [Header("Quit behavior")]
    public string mainMenuSceneName = ""; // ex: "MainMenu" si tu as une scene menu

    private bool isPaused;

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        isPaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Pour tester au clavier (en VR on changera plus tard)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        if (pausePanel != null) pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        if (pausePanel != null) pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Time.timeScale = 1f;

        // Si tu as une scène Menu, mets son nom dans mainMenuSceneName
        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            SceneManager.LoadScene(mainMenuSceneName);
            return;
        }

        // Sinon, on reload la scène actuelle (pratique en dev)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // (Ou fermer l'app en build) :
        // Application.Quit();
    }
}

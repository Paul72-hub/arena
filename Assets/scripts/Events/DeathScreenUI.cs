using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    [Header("UI")]
    public GameObject deathScreen;

    [Header("Gameplay")]
    public GameObject gameplayRoot;   // parent des archers / spawners

    void OnEnable()
    {
        PlayerEvents.OnPlayerDied += Show;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerDied -= Show;
    }

    void Show()
    {
        if (deathScreen != null)
            deathScreen.SetActive(true);

        if (gameplayRoot != null)
            gameplayRoot.SetActive(false);


        Time.timeScale = 0f;
    }

    // ---------- BOUTONS ----------

    public void RestartGame()
    {
        Time.timeScale = 1f;

        if (deathScreen != null)
            deathScreen.SetActive(false);

        if (gameplayRoot != null)
            gameplayRoot.SetActive(true);


        // Reset des vies / état joueur
         PlayerEvents.OnPlayerRestart?.Invoke();
    }

   public void QuitGame()
{
    Time.timeScale = 1f;

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; // stop Play en editor
#else
    Application.Quit(); // quitte le jeu en build
#endif
}



}

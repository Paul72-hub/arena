using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Use this if you are using TextMeshPro

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText; // Drag your Timer Text here
    public GameObject winMenu;        // Drag your WinMenu Panel here
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            WinGame();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Formats the time to show seconds and milliseconds
        timerText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timeToDisplay), (timeToDisplay % 1) * 100);
    }

    void WinGame()
    {
        gameEnded = true;
        timeRemaining = 0;
        winMenu.SetActive(true); // Shows the Win Menu
        Time.timeScale = 0;      // Pauses the game world
    }

    public void ReplayGame()
    {
        Time.timeScale = 1;      // Unpause before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
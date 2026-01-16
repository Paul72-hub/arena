using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text livesText;

    [Header("Lives")]
    public int maxLives = 10;
    public int currentLives;

    void Awake()
    {
        currentLives = maxLives;
        UpdateUI();
    }

    void OnEnable()
    {
        PlayerEvents.OnPlayerHit += LoseLife;
        PlayerEvents.OnPlayerRestart += ResetLives; // ✅
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerHit -= LoseLife;
        PlayerEvents.OnPlayerRestart -= ResetLives; // ✅
    }

    void LoseLife()
    {
        if (currentLives <= 0) return;

        currentLives--;
        UpdateUI();

        if (currentLives <= 0)
        {
            PlayerEvents.OnPlayerDied?.Invoke();
        }
    }

    void ResetLives() // ✅
    {
        currentLives = maxLives;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (livesText != null)
            livesText.text = $"Vies: {currentLives}";
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Configuration des Panneaux")]
    public GameObject menuPrincipal; // Le conteneur de tes boutons de base
    public GameObject panelTuto;     // Le panneau noir transparent

    public void StartGame()
    {
        // Remplace par le nom exact de ta scène de jeu
        SceneManager.LoadScene("Scene_Game");
    }

    public void OpenTutoriel()
    {
        // On affiche le tuto et on peut cacher le menu principal si on veut
        panelTuto.SetActive(true);
        menuPrincipal.SetActive(false);
    }

    public void CloseTutoriel()
    {
        // On fait l'inverse
        panelTuto.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Le jeu a été fermé !");
    }
}
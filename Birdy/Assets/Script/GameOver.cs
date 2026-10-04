using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.Shutdown();
        }
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Retstart()
    {
        Time.timeScale = 1;
        if (pauseMenu != null) pauseMenu.SetActive(false);

        // 1. Déplacer et réinitialiser le joueur EN PREMIER
        Health[] allPlayers = Object.FindObjectsByType<Health>(FindObjectsSortMode.None);

        foreach (Health player in allPlayers)
        {
            if (player.IsOwner) 
            {
                player.respawnPoint = null; 
                player.ResetToStartPosition(); // Le joueur est téléporté au spawn initial loin de la plume

                Playercontroller controller = player.GetComponent<Playercontroller>();
                if (controller != null)
                {
                    controller.canFly = false;
                    controller.JumpingPower = controller.baseJumpingPower;
                }

                break;
            }
        }

        CheckPoint.ResetAllCheckpoints();
        PlusHealth.ResetAllHealthPickups();
        SpecialFeather.ResetAllFeathers();

    }
}
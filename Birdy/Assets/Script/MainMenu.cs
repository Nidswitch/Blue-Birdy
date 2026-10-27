using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform hostSpawnPoint;

    public void PlayGame()
    {
        Time.timeScale = 1f;

        SceneManager.sceneLoaded += OnSceneLoaded;

        SceneManager.LoadSceneAsync("Test Zone");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Test Zone")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            if (NetworkManager.Singleton != null && !NetworkManager.Singleton.IsListening)
            {
                NetworkManager.Singleton.StartHost();

                TeleportHostToSpawnPoint();
            }
        }
    }

    private void TeleportHostToSpawnPoint()
    {
        if (hostSpawnPoint != null)
        {
            if (NetworkManager.Singleton.LocalClient != null && NetworkManager.Singleton.LocalClient.PlayerObject != null)
            {
                NetworkManager.Singleton.LocalClient.PlayerObject.transform.position = hostSpawnPoint.position;
                NetworkManager.Singleton.LocalClient.PlayerObject.transform.rotation = hostSpawnPoint.rotation;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


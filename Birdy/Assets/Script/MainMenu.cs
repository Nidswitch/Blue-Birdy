using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


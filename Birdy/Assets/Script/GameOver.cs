using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Retstart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

// Token: 0x0200000A RID: 10
public class MainMenu : MonoBehaviour
{
	// Token: 0x0600001C RID: 28 RVA: 0x0000248C File Offset: 0x0000068C
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1f;
		SceneManager.LoadSceneAsync("Test Zone");
	}

	// Token: 0x0600001D RID: 29 RVA: 0x000024C0 File Offset: 0x000006C0
	public void QuitGame()
	{
		Application.Quit();
	}
}


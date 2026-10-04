using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentlhealthBar;

    private Health playerHealth;
    private float baseMaxHealth = 10f;

    private void Update()
    {
        if (playerHealth == null)
        {
            FindLocalPlayerHealth();
            return;
        }

        if (playerHealth.maxHealth > 0)
        {
            totalhealthBar.fillAmount = playerHealth.maxHealth / baseMaxHealth;
            currentlhealthBar.fillAmount = playerHealth.currentHealth / baseMaxHealth;
        }
    }

    private void FindLocalPlayerHealth()
    {
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.LocalClient != null)
        {
            var playerObject = NetworkManager.Singleton.LocalClient.PlayerObject;
            if (playerObject != null)
            {
                playerHealth = playerObject.GetComponent<Health>();
            }
        }
    }
}

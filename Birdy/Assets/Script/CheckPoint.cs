using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.respawnPoint = this.gameObject;
                
                playerHealth.AddHealth(playerHealth.maxHealth);

                gameObject.SetActive(false);
            }
        }
    }

    public static void ResetAllCheckpoints()
    {
        CheckPoint[] checkpoints = Resources.FindObjectsOfTypeAll<CheckPoint>();
        
        foreach (CheckPoint cp in checkpoints)
        {
            if (cp != null && cp.gameObject != null && cp.gameObject.scene.isLoaded)
            {
                cp.gameObject.SetActive(true);
            }
        }
    }
}

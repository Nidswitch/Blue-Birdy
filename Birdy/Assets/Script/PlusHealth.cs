using UnityEngine;

public class PlusHealth : MonoBehaviour
{
    [SerializeField] private float bonusMaxHealth = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.IncreaseMaxHealth(bonusMaxHealth);
                gameObject.SetActive(false);
            }
        }
    }

    public static void ResetAllHealthPickups()
    {
        PlusHealth[] healthPickups = Resources.FindObjectsOfTypeAll<PlusHealth>();

        foreach (PlusHealth hp in healthPickups)
        {
            if (hp != null && hp.gameObject != null && hp.gameObject.scene.isLoaded)
            {
                hp.gameObject.SetActive(true);
            }
        }
    }
}

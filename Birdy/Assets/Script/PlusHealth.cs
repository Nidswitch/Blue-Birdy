using UnityEngine;

public class PlusHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float healthValue;
    [SerializeField] private float MoreHealth = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.IncreaseMaxHealth(MoreHealth);
                gameObject.SetActive(false);
            }
        }
    }
}

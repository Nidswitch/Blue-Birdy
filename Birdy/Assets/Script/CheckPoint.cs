using UnityEngine;

public class CheckPoint : MonoBehaviour

{
    private Health respawn;
    [SerializeField] private float MoreHealth = 0f;

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.respawnPoint = this.gameObject;
            }
        }

        if(other.tag == "Player")
        {
            
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.IncreaseMaxHealth(MoreHealth);
                gameObject.SetActive(false);
            }
        }
    }

    
}



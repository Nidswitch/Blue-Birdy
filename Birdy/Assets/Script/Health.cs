using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [SerializeField] private float startingHealth = 5f;
    public float currentHealth { get; private set; }
    public float maxHealth { get; private set; }

    private Vector3 initialSpawnPosition;
    [HideInInspector] public GameObject respawnPoint;

    private void Awake()
    {
        maxHealth = startingHealth;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        initialSpawnPosition = transform.position;
    }

    public void ResetToStartPosition()
    {
        if (IsOwner)
        {
            transform.position = initialSpawnPosition;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }

        maxHealth = startingHealth;
        currentHealth = maxHealth;
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);
    }

    public void IncreaseMaxHealth(float _amount)
    {
        maxHealth += _amount;
        currentHealth = maxHealth;
    }

    public void Respawn()
    {
        if (IsOwner)
        {
            Vector3 targetPos = (respawnPoint != null) ? respawnPoint.transform.position : initialSpawnPosition;
            transform.position = targetPos;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }

        currentHealth = maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }
}



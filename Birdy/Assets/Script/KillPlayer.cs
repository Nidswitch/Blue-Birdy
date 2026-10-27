using System;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float damageInterval = 1f;
    private float cooldownTimer;

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cooldownTimer <= 0)
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                
                // Réinitialise le cooldown
                cooldownTimer = damageInterval;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cooldownTimer = 0f;
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    public float maxHealth { get; private set;}
    private bool dead;
    public GameObject player;
    public Transform respawnPoint;
    
    

    private void Awake()
    {
        maxHealth = startingHealth;
        currentHealth = maxHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);
        Debug.Log("Vie restante : " + currentHealth);
    

        if(currentHealth <= 0)
        {
            player.transform.position = respawnPoint.position;
            currentHealth = maxHealth;
        }

        
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);
    }
    
    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth;
    }

    
}



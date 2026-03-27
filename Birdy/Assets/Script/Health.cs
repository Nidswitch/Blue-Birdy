using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    private bool dead;
    public GameObject player;
    public Transform respawnPoint;
    
    

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
    

        if(currentHealth <= 0)
        {
            player.transform.position = respawnPoint.position;
            AddHealth(startingHealth);
        }

        
    }

public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    
    

    
}



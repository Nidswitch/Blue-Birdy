using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentlhealthBar;

    private float baseMaxHealth = 10f;


    private void Update()
    {
        totalhealthBar.fillAmount = playerHealth.maxHealth / baseMaxHealth;
        currentlhealthBar.fillAmount = playerHealth.currentHealth / baseMaxHealth;
    }
}

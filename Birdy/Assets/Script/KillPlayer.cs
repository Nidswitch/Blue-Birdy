using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class KillPlayer : MonoBehaviour


{
    
[SerializeField] private float damage;

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    

    
}

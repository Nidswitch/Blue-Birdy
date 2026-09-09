using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyEnemy : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;

    private float dazedTime;
    public float startDazedTime; // Temps d'étourdissement en secondes
    public int health;
    private Rigidbody2D rb;

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime; // Applique le délai d'étourdissement
        health -= damage;
        Debug.Log("Dégâts reçus ! Vie restante : " + health);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        if (player != null)
    {
        Collider2D enemyCollider = GetComponent<Collider2D>();
        Collider2D playerCollider = player.GetComponent<Collider2D>();

        if (enemyCollider != null && playerCollider != null)
        {
            Physics2D.IgnoreCollision(enemyCollider, playerCollider, true);
        }
    }
    }

    void Update()
    {
        if (player == null) return;
        
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        if (dazedTime > 0)
        {
            dazedTime -= Time.deltaTime;
            return; // Bloque le reste de Update (l'ennemi ne bouge plus)
        }

        if (chase)
            Chase();
        else
            ReturnStartPoint();

        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        if (startingPoint != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }    
}
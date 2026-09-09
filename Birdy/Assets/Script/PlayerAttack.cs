using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public Transform attackPos2;
    public Transform attackPos3;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsSpikes;
    
    public float attackRangeX;
    public float attackRangeY;
    public float attackRangeX2;
    public float attackRangeY2;
    public float attackRangeX3;
    public float attackRangeY3;

    public int damage;
    private Playercontroller playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<Playercontroller>();
    }

    private void Update()
    {
        if (timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                bool hasAttacked = false;

                // ATTAQUE HAUT (W)
                if (Input.GetKey(KeyCode.W))
                {
                    Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPos2.position, new Vector2(attackRangeX2, attackRangeY2), 0f, whatIsEnemies);
                    DealDamageToEnemies(hitEnemies);
                    hasAttacked = true;
                }
                // ATTAQUE BAS / POGO (S)
                else if (Input.GetKey(KeyCode.S)) 
                {
                    Collider2D[] hitObjects = Physics2D.OverlapBoxAll(attackPos3.position, new Vector2(attackRangeX3, attackRangeY3), 0f);
                    
                    if (hitObjects.Length > 0)
                    {
                        bool hitSomethingToBounce = false;

                        for (int j = 0; j < hitObjects.Length; j++)
                        {
                            // Vérifie si c'est un ennemi au sol
                            Patrol1 patrolEnemy = hitObjects[j].GetComponent<Patrol1>();
                            if (patrolEnemy != null)
                            {
                                patrolEnemy.TakeDamage(damage);
                                hitSomethingToBounce = true;
                            }

                            // Vérifie si c'est un ennemi volant
                            FlyEnemy flyEnemy = hitObjects[j].GetComponent<FlyEnemy>();
                            if (flyEnemy != null)
                            {
                                flyEnemy.TakeDamage(damage);
                                hitSomethingToBounce = true;
                            }

                            // Vérifie si ce sont des piques
                            if (((1 << hitObjects[j].gameObject.layer) & whatIsSpikes) != 0)
                            {
                                hitSomethingToBounce = true;
                            }
                        }

                        if (hitSomethingToBounce && playerMovement != null)
                        {
                            playerMovement.Pogo();
                        }
                    }
                    hasAttacked = true;
                }
                // ATTAQUE NORMALE (FACE)
                else 
                {
                    Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0f, whatIsEnemies);
                    DealDamageToEnemies(hitEnemies);
                    hasAttacked = true;
                }

                if (hasAttacked)
                {
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
        }
    }

    // Applique les dégâts à Patrol1 ET FlyEnemy
    private void DealDamageToEnemies(Collider2D[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            Patrol1 patrolEnemy = targets[i].GetComponent<Patrol1>();
            if (patrolEnemy != null)
            {
                patrolEnemy.TakeDamage(damage);
            }

            FlyEnemy flyEnemy = targets[i].GetComponent<FlyEnemy>();
            if (flyEnemy != null)
            {
                flyEnemy.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (attackPos != null) Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1f));
        if (attackPos2 != null) Gizmos.DrawWireCube(attackPos2.position, new Vector3(attackRangeX2, attackRangeY2, 1f));
        if (attackPos3 != null) Gizmos.DrawWireCube(attackPos3.position, new Vector3(attackRangeX3, attackRangeY3, 1f));
    }
}

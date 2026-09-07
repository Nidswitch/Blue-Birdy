using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BactosRedQueue : MonoBehaviour
{
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        DealDamage(attackDamage);
    }

    public void EnragedAttack()
    {
        DealDamage(enragedAttackDamage);
    }

    private void DealDamage(int damage)
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            // Recherche du composant Health sur l'objet ou ses parents
            Health playerHealth = colInfo.GetComponent<Health>();
            if (playerHealth == null)
            {
                playerHealth = colInfo.GetComponentInParent<Health>();
            }

            // Application des dégâts en toute sécurité
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
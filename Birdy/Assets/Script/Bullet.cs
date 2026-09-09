using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
	public int damage = 3;
	// Token: 0x04000041 RID: 65
	public Rigidbody2D rb;
	private void Start()
	{
        if (rb == null) rb = GetComponent<Rigidbody2D>();
		rb.linearVelocity = base.transform.right * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
	private void OnTriggerEnter2D(Collider2D hitInfo)
    {

		if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Wall"))
        {
            return;
        }

        Patrol1 patrolEnemy = hitInfo.GetComponent<Patrol1>();
        if (patrolEnemy != null)
        {
            patrolEnemy.TakeDamage(damage);
            Destroy(gameObject);
            return; 
        }

        FlyEnemy flyingEnemy = hitInfo.GetComponent<FlyEnemy>();
        if (flyingEnemy != null)
        {
            flyingEnemy.TakeDamage(damage);
            Destroy(gameObject);
            return; 
        }
        
        Destroy(gameObject);
        
    }


	
}

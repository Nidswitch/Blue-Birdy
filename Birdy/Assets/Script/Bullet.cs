using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class Bullet : MonoBehaviour
{
	// Token: 0x0600002C RID: 44 RVA: 0x00002C68 File Offset: 0x00000E68
	private void Start()
	{
		this.rb.linearVelocity = base.transform.right * this.speed;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002C90 File Offset: 0x00000E90
	private void OnTriggerEnter2D(Collider2D hitInfo)
	{
		Patrol component = hitInfo.GetComponent<Patrol>();
		if (component != null)
		{
			component.TakeDamage(this.damage);
		}
		Destroy(gameObject);
	}

	// Token: 0x0400003F RID: 63
	public float speed = 20f;

	// Token: 0x04000040 RID: 64
	public int damage = 3;

	// Token: 0x04000041 RID: 65
	public Rigidbody2D rb;
}

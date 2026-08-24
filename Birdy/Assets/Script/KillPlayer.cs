using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class KillPlayer : MonoBehaviour
{
	// Token: 0x0600001A RID: 26 RVA: 0x0000245F File Offset: 0x0000065F
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.GetComponent<Health>().TakeDamage(damage);
		}
	}

	// Token: 0x0400001C RID: 28
	[SerializeField] private float damage;
}

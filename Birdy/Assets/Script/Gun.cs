using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Gun : MonoBehaviour
{
	// Token: 0x0600000E RID: 14 RVA: 0x000022F8 File Offset: 0x000004F8
	private void Update()
	{
		if ((double)this.timeBtwAttack <= 0.5)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				this.Shoot();
			}
			this.timeBtwAttack = this.startTimeBtwAttack;
			return;
		}
		this.timeBtwAttack -= Time.deltaTime;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002348 File Offset: 0x00000548
	private void Shoot()
	{
		Instantiate<GameObject>(this.bulletPrefab, this.firePoint.position, this.firePoint.rotation);
	}

	// Token: 0x04000010 RID: 16
	private float timeBtwAttack;

	// Token: 0x04000011 RID: 17
	public float startTimeBtwAttack;

	// Token: 0x04000012 RID: 18
	public Transform firePoint;

	// Token: 0x04000013 RID: 19
	public GameObject bulletPrefab;
}

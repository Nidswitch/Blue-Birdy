using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class PlayerAttack : MonoBehaviour
{
	// Token: 0x06000022 RID: 34 RVA: 0x000026B8 File Offset: 0x000008B8
	private void Update()
	{
		if ((double)this.timeBtwAttack <= 0.2)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.W))
			{
				Collider2D[] array = Physics2D.OverlapBoxAll(this.attackPos2.position, new Vector2(this.attackRangeX2, this.attackRangeY2), 0f, this.whatIsEnemies);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].GetComponent<Patrol>().TakeDamage(this.damage);
				}
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.S))
			{
				Collider2D[] array2 = Physics2D.OverlapBoxAll(this.attackPos3.position, new Vector2(this.attackRangeX3, this.attackRangeY3), 0f, this.whatIsEnemies);
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j].GetComponent<Patrol>().TakeDamage(this.damage);
				}
			}
			else if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Collider2D[] array3 = Physics2D.OverlapBoxAll(this.attackPos.position, new Vector2(this.attackRangeX, this.attackRangeY), 0f, this.whatIsEnemies);
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k].GetComponent<Patrol>().TakeDamage(this.damage);
				}
			}
			this.timeBtwAttack = this.startTimeBtwAttack;
			return;
		}
		this.timeBtwAttack -= Time.deltaTime;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002844 File Offset: 0x00000A44
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(this.attackPos.position, new Vector3(this.attackRangeX, this.attackRangeY, 1f));
		Gizmos.DrawWireCube(this.attackPos2.position, new Vector3(this.attackRangeX2, this.attackRangeY2, 1f));
		Gizmos.DrawWireCube(this.attackPos3.position, new Vector3(this.attackRangeX3, this.attackRangeY3, 1f));
	}

	// Token: 0x04000027 RID: 39
	private float timeBtwAttack;

	// Token: 0x04000028 RID: 40
	public float startTimeBtwAttack;

	// Token: 0x04000029 RID: 41
	public Transform attackPos;

	// Token: 0x0400002A RID: 42
	public Transform attackPos2;

	// Token: 0x0400002B RID: 43
	public Transform attackPos3;

	// Token: 0x0400002C RID: 44
	public LayerMask whatIsEnemies;

	// Token: 0x0400002D RID: 45
	public float attackRangeX;

	// Token: 0x0400002E RID: 46
	public float attackRangeY;

	// Token: 0x0400002F RID: 47
	public float attackRangeX2;

	// Token: 0x04000030 RID: 48
	public float attackRangeY2;

	// Token: 0x04000031 RID: 49
	public float attackRangeX3;

	// Token: 0x04000032 RID: 50
	public float attackRangeY3;

	// Token: 0x04000033 RID: 51
	public int damage;
}

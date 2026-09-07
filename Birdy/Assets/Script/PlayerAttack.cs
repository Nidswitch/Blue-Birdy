using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
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

                if (Input.GetKey(KeyCode.W))
                {
                    Collider2D[] array = Physics2D.OverlapBoxAll(attackPos2.position, new Vector2(attackRangeX2, attackRangeY2), 0f, whatIsEnemies);
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].GetComponent<Patrol1>() != null) 
                            array[i].GetComponent<Patrol1>().TakeDamage(damage);
                    }
                    hasAttacked = true;
                }
                else if (Input.GetKey(KeyCode.S)) 
                {
                    LayerMask combinedMask = whatIsEnemies | whatIsSpikes;
                    Collider2D[] array2 = Physics2D.OverlapBoxAll(attackPos3.position, new Vector2(attackRangeX3, attackRangeY3), 0f);
                    
                    if (array2.Length > 0)
                    {
                        bool hitSomethingToBounce = false;

                        for (int j = 0; j < array2.Length; j++)
                        {
                            if (array2[j].GetComponent<Patrol1>() != null) 
                            {
                                array2[j].GetComponent<Patrol1>().TakeDamage(damage);
                                hitSomethingToBounce = true;
                            }
                            else if (((1 << array2[j].gameObject.layer) & whatIsSpikes) != 0)
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
                else 
                {
                    Collider2D[] array3 = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0f, whatIsEnemies);
                    for (int k = 0; k < array3.Length; k++)
                    {
                        if (array3[k].GetComponent<Patrol1>() != null) 
                            array3[k].GetComponent<Patrol1>().TakeDamage(damage);
                    }
                    hasAttacked = true;
                }

                if (hasAttacked)
                {
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
        }
    }

	// Token: 0x06000023 RID: 35 RVA: 0x00002844 File Offset: 0x00000A44
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1f));
		Gizmos.DrawWireCube(attackPos2.position, new Vector3(attackRangeX2, attackRangeY2, 1f));
		Gizmos.DrawWireCube(attackPos3.position, new Vector3(attackRangeX3, attackRangeY3, 1f));
	}

}

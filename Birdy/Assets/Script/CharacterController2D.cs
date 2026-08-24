using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000004 RID: 4
public class CharacterController2D : MonoBehaviour
{
	// Token: 0x06000006 RID: 6 RVA: 0x000021E1 File Offset: 0x000003E1
	private void Awake()
	{
		this.m_Rigidbody2D = base.GetComponent<Rigidbody2D>();
		if (this.OnLandEvent == null)
		{
			this.OnLandEvent = new UnityEvent();
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002204 File Offset: 0x00000404
	private void FixedUpdate()
	{
		bool grounded = this.m_Grounded;
		this.m_Grounded = false;
		Collider2D[] array = Physics2D.OverlapCircleAll(this.m_GroundCheck.position, 0.2f, this.m_WhatIsGround);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].gameObject != base.gameObject)
			{
				this.m_Grounded = true;
				if (!grounded)
				{
					this.OnLandEvent.Invoke();
				}
			}
		}
	}

	// Token: 0x04000009 RID: 9
	[SerializeField]
	private LayerMask m_WhatIsGround;

	// Token: 0x0400000A RID: 10
	[SerializeField]
	private Transform m_GroundCheck;

	// Token: 0x0400000B RID: 11
	private const float k_GroundedRadius = 0.2f;

	// Token: 0x0400000C RID: 12
	private bool m_Grounded;

	// Token: 0x0400000D RID: 13
	private Rigidbody2D m_Rigidbody2D;

	// Token: 0x0400000E RID: 14
	[Header("Events")]
	[Space]
	public UnityEvent OnLandEvent;

	// Token: 0x02000011 RID: 17
	[Serializable]
	public class BoolEvent : UnityEvent<bool>
	{
	}
}



	


	
		

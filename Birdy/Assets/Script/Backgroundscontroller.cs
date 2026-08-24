using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class Backgroundscontroller : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		this.startPos = base.transform.position.x;
		this.length = base.GetComponent<SpriteRenderer>().bounds.size.x;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002094 File Offset: 0x00000294
	private void FixedUpdate()
	{
		float num = this.cam.transform.position.x * this.parallaxEffect;
		float num2 = this.cam.transform.position.x * (1f - this.parallaxEffect);
		base.transform.position = new Vector3(this.startPos + num, base.transform.position.y, base.transform.position.z);
		if (num2 > this.startPos + this.length)
		{
			this.startPos += this.length;
			return;
		}
		if (num2 < this.startPos - this.length)
		{
			this.startPos -= this.length;
		}
	}

	// Token: 0x04000001 RID: 1
	private float startPos;

	// Token: 0x04000002 RID: 2
	private float length;

	// Token: 0x04000003 RID: 3
	public GameObject cam;

	// Token: 0x04000004 RID: 4
	public float parallaxEffect;
}

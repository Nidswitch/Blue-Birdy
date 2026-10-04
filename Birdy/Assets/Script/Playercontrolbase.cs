using UnityEngine;

public class Playercontrolbase : MonoBehaviour
{
	// Token: 0x06000025 RID: 37 RVA: 0x000028D8 File Offset: 0x00000AD8
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			isTopDownMode = !isTopDownMode;
			if (isTopDownMode)
			{
				rb.gravityScale = 0f;
				rb.linearVelocity = Vector2.zero;
			}
			else
			{
				rb.gravityScale = 3f;
			}
		}
		if (isTopDownMode)
		{
			float axisRaw = Input.GetAxisRaw("Horizontal");
			float axisRaw2 = Input.GetAxisRaw("Vertical");
			rb.linearVelocity = new Vector2(axisRaw, axisRaw2).normalized * isTopDownSpeed;
			if (!animator.GetBool("isAttacking") && !animator.GetBool("IsShooting"))
			{
				animator.SetBool("IsJumping", true);
			}
			else
			{
				animator.SetBool("IsJumping", false);
			}
			horizontal = axisRaw;
		}
		else
		{
			horizontal = Input.GetAxisRaw("Horizontal");
			animator.SetFloat("Speed", Mathf.Abs(horizontal));
			if (Input.GetButtonDown("Jump") && IsGrounded())
			{
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpingPower);
				animator.SetBool("IsJumping", true);
			}
			if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
			{
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
			}
			if (!IsGrounded() && !animator.GetBool("isAttacking") && !animator.GetBool("IsShooting"))
			{
				animator.SetBool("IsJumping", true);
			}
			
		}
		animator.SetFloat("yVelocity", rb.linearVelocity.y);
		if (horizontal > 0.01f || horizontal < -0.01f)
		{
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}
		if (Input.GetMouseButtonDown(0))
		{
			animator.SetBool("isAttacking", true);
			animator.SetBool("IsJumping", false);
		}
		if (Input.GetButtonDown("Fire1"))
		{
			animator.SetBool("IsShooting", true);
			animator.SetBool("IsJumping", false);
		}
		Flip();
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002B3C File Offset: 0x00000D3C
	public void endAttack()
	{
		animator.SetBool("isAttacking", false);
		animator.SetBool("IsShooting", false);
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002B60 File Offset: 0x00000D60
	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002B73 File Offset: 0x00000D73
	private void FixedUpdate()
	{
		if (!isTopDownMode)
		{
			rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
		}
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002BAA File Offset: 0x00000DAA
	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002BD8 File Offset: 0x00000DD8
	private void Flip()
	{
		if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
		{
			isFacingRight = !isFacingRight;
			transform.Rotate(0f, 180f, 0f);
		}
	}

	// Token: 0x04000034 RID: 52
	public CharacterController2D controller;

	// Token: 0x04000035 RID: 53
	public Animator animator;

	// Token: 0x04000036 RID: 54
	private float horizontal;

	// Token: 0x04000037 RID: 55
	[SerializeField]
	private float speed = 5f;

	// Token: 0x04000038 RID: 56
	[SerializeField]
	private float JumpingPower = 6f;

	// Token: 0x04000039 RID: 57
	private bool isFacingRight = true;

	// Token: 0x0400003A RID: 58
	[SerializeField]
	private Rigidbody2D rb;

	// Token: 0x0400003B RID: 59
	[SerializeField]
	private Transform groundCheck;

	// Token: 0x0400003C RID: 60
	[SerializeField]
	private LayerMask groundLayer;

	// Token: 0x0400003D RID: 61
	private bool isTopDownMode;

	// Token: 0x0400003E RID: 62
	[SerializeField]
	private float isTopDownSpeed = 6f;
}
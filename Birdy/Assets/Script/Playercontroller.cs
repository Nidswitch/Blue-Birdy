using System;
using UnityEngine;
public class Playercontroller : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;
	private float horizontal;
	[SerializeField] private float speed = 5f;
	[SerializeField] private float JumpingPower = 16f;
	[SerializeField] private float FlyJumpPower = 10f;
	private bool isFacingRight = true;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	private bool isTopDownMode;
	[SerializeField] private float isTopDownSpeed = 6f;
	[SerializeField] private float glideSpeed = 2f;
	private bool canFly = false;

    [SerializeField] private float bouncePower = 12f;
	
	
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
			if (!animator.GetBool("isAttacking") && !animator.GetBool("isAttackingUp") && !animator.GetBool("isAttackingDown") && !animator.GetBool("IsShooting"))
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
			if (Input.GetButtonDown("Jump") && (IsGrounded() || canFly))
			{
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpingPower);
				animator.SetBool("IsJumping", true);
			}
			if (Input.GetKey(KeyCode.LeftShift) && !IsGrounded() && rb.linearVelocity.y < 0 && canFly)
			{
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, - glideSpeed);
			}
			if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
			{
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
			}
			if (!IsGrounded() && !animator.GetBool("isAttacking") && !animator.GetBool("isAttackingUp") && !animator.GetBool("isAttackingDown") && !animator.GetBool("IsShooting"))
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
		if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.S))
		{
			animator.SetBool("isAttacking", true);
			animator.SetBool("IsJumping", false);
		}
		if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.W))
		{
			animator.SetBool("isAttackingUp", true);
			animator.SetBool("isAttackingDown", false);
			animator.SetBool("isAttacking", false);
			animator.SetBool("IsJumping", false);
		}
		if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.S) && !IsGrounded())
		{
			animator.SetBool("isAttackingDown", true);
			animator.SetBool("isAttackingUp", false);
			animator.SetBool("isAttacking", false);
			animator.SetBool("IsJumping", false);
		}
		if (Input.GetButtonDown("Fire1"))
		{
			animator.SetBool("IsShooting", true);
			animator.SetBool("IsJumping", false);
		}
		Flip();
	}

	public void Pogo()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bouncePower);
        animator.SetBool("isAttackingDown", true);
    }

	// Token: 0x06000026 RID: 38 RVA: 0x00002B3C File Offset: 0x00000D3C
	public void endAttack()
	{
		animator.SetBool("isAttackingDown", false);
		animator.SetBool("isAttacking", false);
		animator.SetBool("isAttackingUp", false);
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
		return Physics2D.OverlapCircle(groundCheck.position, 0.25f, groundLayer);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Special feather"))
		{
			canFly = true;
			JumpingPower = FlyJumpPower;
			Destroy(collision.gameObject);
		}
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
	
}

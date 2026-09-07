using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class Patrol1 : MonoBehaviour
{

    public float speed = -2f;
    private float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    public Animator animator1;
    [SerializeField]
    private LayerMask groundLayer;
    private float horizontal;
    public int health;
    private float dazedTime;
    public float startDazedTime;
    // Token: 0x0600001F RID: 31 RVA: 0x000024CF File Offset: 0x000006CF
    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("damage TAKEN !");
    }

    // Token: 0x06000020 RID: 32 RVA: 0x000024F8 File Offset: 0x000006F8
    private void Update()
    {
        if (dazedTime <= 0f)
        {
            speed = -1f;
        }
        else
        {
            speed = 0f;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        base.transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator1.SetFloat("Speed1", Mathf.Abs(distance));
        if (!Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f).collider)
        {
            if (movingRight)
            {
                base.transform.eulerAngles = new Vector3(0f, -180f, 0f);
                movingRight = false;
            }
            else
            {
                base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                movingRight = true;
            }
        }
        if (Physics2D.Raycast(groundDetection.position, Vector2.right, 0.001f).collider)
        {
            if (movingRight)
            {
                base.transform.eulerAngles = new Vector3(0f, -180f, 0f);
                movingRight = false;
                return;
            }
            base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            movingRight = true;
        }
    }

}

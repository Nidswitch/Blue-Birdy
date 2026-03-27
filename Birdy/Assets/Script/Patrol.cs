using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
    public float speed = -2;
    private float distance;

    private bool movingRight = true;

    public Transform groundDetection;
    
    public Animator animator1;

    [SerializeField] private LayerMask groundLayer;
    private float horizontal;
    public int health;
    private float dazedTime;
    public float startDazedTime;


    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("damage TAKEN !");
    }

    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = -1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator1.SetFloat("Speed1", Mathf.Abs(distance));

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f);
        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0.001f);
        if (wallInfo.collider == true)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    
        


    }

    
}

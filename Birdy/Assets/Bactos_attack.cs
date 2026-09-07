using UnityEngine;

public class Bactos_attack : StateMachineBehaviour
{
    public float attackRange = 1f;

    Transform player;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);

        if (player == null || rb == null) return;
    float directionToPlayer = player.position.x - rb.position.x;
    float enemyFacingDirection = animator.transform.right.x > 0 ? 1f : -1f;
    bool isPlayerInFront = (directionToPlayer * enemyFacingDirection) < 0;
    bool isWithinRange = Vector2.Distance(player.position, rb.position) <= attackRange;
    if (isPlayerInFront && isWithinRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}